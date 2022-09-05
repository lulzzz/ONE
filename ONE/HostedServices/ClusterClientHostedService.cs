
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ONE.GrainInterfaces;
using Orleans;
using Orleans.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ONE.HostedServices
{
    /// <summary>
    /// If orleans silo is not being co-hosted with the web gateway the cluster client needs to be created and connected 
    /// This service is used to start it and make it available to dependency injection
    /// </summary>
    internal class ClusterClientHostedService : IHostedService
    {
        public IClusterClient Client { get; }

        public ClusterClientHostedService(ILoggerProvider loggerProvider, IOptions<ONEHostingOptions> hostingOptions)
        {
            var builder = new ClientBuilder()
                .UseDashboard()
                .ConfigureLogging(builder => builder.AddProvider(loggerProvider));

            if (hostingOptions.Value.Mode == HostMode.Cloud)
            {
                // setup cloud clustering (ie table storage etc)
                // TODO:
                throw new NotSupportedException("Cloud clustering has not yet been implemented");
            }
            else
            {
                builder.UseLocalhostClustering(30000, "one_local", "one_local");
                builder.AddSimpleMessageStreamProvider(ONEStreams.DefaultProvider);
            }

            Client = builder.Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Client.Connect();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Client.Close();

            Client.Dispose();
        }
    }

    public static class ClusterClientHostedServiceExtensions
    {
        /// <summary>
        /// Adds a cluster client 
        /// This is only necessary when not co-hosting with the silo
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddExternalClusterClient(this IServiceCollection services)
        {
            services.AddSingleton<ClusterClientHostedService>();
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<ClusterClientHostedService>());
            services.AddSingleton<IClusterClient>(sp => sp.GetRequiredService<ClusterClientHostedService>().Client);
            services.AddSingleton<IGrainFactory>(sp => sp.GetRequiredService<ClusterClientHostedService>().Client);
            return services;
        }
    }
}
