using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore.Extensions;
using ONE.Common.Helpers;
using ONE.GrainInterfaces;
using ONE.HostedServices;
using ONE.Odin.Web;
using ONE.Silo.Grains;
using Orleans;
using Orleans.Hosting;
using Orleans.Statistics;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ONE
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Environment.CurrentDirectory = AppContext.BaseDirectory;

            // since we need a couple of options to use while configuring the host we'll use a dummy host and bind the options for that
            // so that is uses all the default config source like ENV vars, cmd line settings, config file etc
            var hostMode = Host.CreateDefaultBuilder(args).Build().Services.GetService<IConfiguration>().Get<ONEHostingOptions>();

            // default builder
            var hostbuilder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((ctx, serivces) => serivces.Configure<ONEHostingOptions>(ctx.Configuration));

            if (hostMode.Services.HasFlag(CloudServices.WebGateway))
            {
                hostbuilder.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(
                        o =>
                        {
                            //o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);

                            o.ListenAnyIP(1883, l => l.UseMqtt()); // MQTT pipeline
                            o.ListenAnyIP(8883, l => l.UseHttps().UseMqtt());

                            // todo SSL on MQTT 8883?, this could be handled by ingress load balancer

                            // o.ListenAnyIP(5555); // custom TCP handler 

                            o.ListenAnyIP(5000); // Default HTTP pipeline
                            o.ListenAnyIP(5001, l => l.UseHttps()); // Default HTTPS pipeline

                        });

                    // web startup and configuration for Web Gateway
                    webBuilder.UseStartup<WebStartup>();
                });

                // we aren't running a silo host, we need to configure an orleans Cluster client as we don't already have access to one
                if (!hostMode.Services.HasFlag(CloudServices.Silo))
                {
                    hostbuilder.ConfigureServices((hostContex, services) =>
                    {
                        services.AddExternalClusterClient();
                    });
                }
            }

            if (hostMode.Services.HasFlag(CloudServices.Silo))
            {
                //if running silo host
                hostbuilder.UseOrleans((hostContext, silo) =>
                {
                    // Use localhost clustering for a single local silo
                    if (hostMode.Mode == HostMode.Cloud)
                    {
                        throw new NotSupportedException("Cloud hosting is not yet implemented");
                    }
                    else
                    {
                        // TODO: Print the ports if they are not the default
                        int siloPort = NetworkHelper.GetAvailablePort(11111);
                        int gatewayPort = NetworkHelper.GetAvailablePort(30000);

                        silo.UseLocalhostClustering(siloPort,
                            gatewayPort,
                            new IPEndPoint(IPAddress.Loopback, 11111), "one_local", "one_local");

                        silo.UseInMemoryReminderService();
                        silo.AddMemoryGrainStorageAsDefault();
                        silo.ConfigureApplicationParts(parts =>
                           {
                               parts.AddApplicationPart(typeof(IGrainMarker).Assembly).WithReferences();
                           });
                        silo.AddSimpleMessageStreamProvider(ONEStreams.DefaultProvider, configure =>
                        {
                            configure.OptimizeForImmutableData = true;
                            configure.PubSubType = Orleans.Streams.StreamPubSubType.ExplicitGrainBasedAndImplicit;
                        });
                        silo.AddMemoryGrainStorage("PubSubStore");  // special storage provider for stream subscriptions
                        silo.AddAzureBlobGrainStorage(
                        name: "oneDataStore",
                        configureOptions: options =>
                        {
                            options.UseJson = true;
                            options.ContainerName = "orlean-blob";
                            options.ConfigureBlobServiceClient("DefaultEndpointsProtocol=https;AccountName=odindev001diag;AccountKey=+dKz9P6uZK1E6o2yEVzAjL0+2rvgF5wS2AEVt7AQ3P8Ik408CrQXPM8y1GE31ufKgqgH7sk8yqb+R8E8o0XizQ==;EndpointSuffix=core.windows.net");
                        }
                        );
                    }

                    // since we have a web layer we will host the UI there
                    silo.UseDashboard(c => c.HostSelf = false);

                    // perf counters for linux and windows
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        silo.UsePerfCounterEnvironmentStatistics(); // windows stats
                    }
                    else
                    {
                        silo.UseLinuxEnvironmentStatistics(); // linux stats 
                    }
                });

                hostbuilder.ConfigureServices(services =>
                {
                    // once started boot any odin devices
                    //services.AddHostedService<BootONESupervisorService>();

                });
            }

            if (hostMode.Mode == HostMode.OnPrem)
            {
                // if running edge device services
                hostbuilder.ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
              
                });
            }

            var host = hostbuilder.Build();

            await host.RunAsync();
            return 0;
        }
    }
}
