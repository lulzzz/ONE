using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.Client.Receiving;
using MQTTnet.Server;
using ONE.DataAccess;
using ONE.GrainInterfaces;
using ONE.Models.Domain;
using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ONE.Web
{
    //TODO: This class has to be moved to ONE.Compute
    public class MqttClientTransportAdapter : IMqttServerApplicationMessageInterceptor, IMqttServerClientConnectedHandler, IMqttServerClientDisconnectedHandler,
        IMqttServerSubscriptionInterceptor, IMqttServerConnectionValidator, IMqttApplicationMessageReceivedHandler
    {
        private readonly ILogger _logger;
        private readonly IClusterClient _cluster;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<string, StreamSubscriptionHandle<IONEEventOutputMessage>> _subscriptions;

        public MqttClientTransportAdapter(IServiceProvider serviceProvider, IClusterClient clusterClient, ILogger<MqttClientTransportAdapter> logger)
        {
            _cluster = clusterClient;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _subscriptions = new ConcurrentDictionary<string, StreamSubscriptionHandle<IONEEventOutputMessage>>();
        }

        protected MqttHostedServer MqttServer => _serviceProvider.GetRequiredService<MqttHostedServer>();

        public async Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
        {


        }

        public async Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
        {
            var deviceID = eventArgs.ClientId;
        }

        public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            // only allow certain topics
            // do this in a better way
            if (context.ApplicationMessage.Topic.StartsWith("dev/data") || context.ApplicationMessage.Topic.StartsWith("/dev/cmd"))
            {
                // do something here
            }
            else
            {
                context.AcceptPublish = false; // don't actually publish
            }
            return Task.CompletedTask;
        }

        public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            // TODO: validate security/ valid client ID
            return Task.CompletedTask;
        }

        public Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context)
        {
            // TODO: validate only certain subsriptions
            return Task.CompletedTask;
        }

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.ClientId != null)
                {
                   
                    eventArgs.AutoAcknowledge = true;
                    string systemIOId = eventArgs.ClientId;
                    string systemIOType = eventArgs.ApplicationMessage.Topic.Split('/')[2];
                    _logger.LogInformation($"Topic {systemIOType}");
                    var streamProvider = _cluster.GetStreamProvider(ONEStreams.DefaultProvider);
                    var stream = streamProvider.GetStream<Immutable<byte[]>>(GrainIdHelpers.GetGrainIdAsGuid(systemIOId), systemIOType);
                    await stream.OnNextAsync(eventArgs.ApplicationMessage.Payload.AsImmutable());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in HandleApplicationMessageReceivedAsync.");
            }
        }
    }
}
