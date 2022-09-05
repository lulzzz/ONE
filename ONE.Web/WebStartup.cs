using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.Extensions;
using MQTTnet.Server;
using ONE.Web;
using ONE.Web.Extensions;
using Orleans;
using System;
using System.Linq;
using System.Reflection;

namespace ONE.Odin.Web
{
    public class WebStartup
    {
        public WebStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSockets(opt =>
            {
                // keep alive pings to prevent proxies from killing connection
                opt.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });

            // add the servcies for the dashboard
            services.AddServicesForSelfHostedDashboard(null, dashboardOpt =>
            {
                dashboardOpt.HideTrace = true;
            });

            services.AddSingleton<MqttClientTransportAdapter>();
            services.AddHostedMqttServer(mqttServer => mqttServer.WithoutDefaultEndpoint())           
                .AddMqttConnectionHandler();

            // add support for custom connection handlers (such as MQTT, custom TCP, WS etc)
            services.AddConnections();

            // razor pages, controllers, apis, etc
            services.AddRazorPages();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // server static file content (ie wwwroot) from embedded resource
            var manifestEmbeddedProvider = new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly(), "wwwroot");
            var staticFilesOptions = new StaticFileOptions
            {
                FileProvider = manifestEmbeddedProvider
            };
            app.UseStaticFiles(staticFilesOptions);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();               

                // mqtt over web sockets
                endpoints.MapConnectionHandler<MqttConnectionHandler>("/mqtt", httpConnectionDispatcherOptions => httpConnectionDispatcherOptions.WebSockets.SubProtocolSelector = protocolList => protocolList.FirstOrDefault() ?? string.Empty);
                endpoints.MapControllers();

                // add the orleans dashboard endpoint
                endpoints.MapOrleansDashboard("/orleans"); // TODO; add RequireAuthorization once we have admin auth
            });


            app.UseMqttServer(server =>
            {
                var transportAdapter = app.ApplicationServices.GetRequiredService<MqttClientTransportAdapter>();
                // anything that would need to be done with the server
              
                server.ClientConnectedHandler = transportAdapter;
                server.ClientDisconnectedHandler = transportAdapter;
                server.UseApplicationMessageReceivedHandler(transportAdapter.HandleApplicationMessageReceivedAsync);
            });
        }
    }

}
