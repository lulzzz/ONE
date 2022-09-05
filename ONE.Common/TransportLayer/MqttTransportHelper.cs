using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Threading.Tasks;

namespace ONE.EdgeCompute.TransportLayer
{
    public class MqttTransportHelper : IMqttTransportHelper
    {
        public IManagedMqttClient managedMqttClient { get; set; }
        public ManagedMqttClientOptions options { get; set; }
        public void OpenMqttTransportConnection(string systemIOGuid)
        {

            options = new ManagedMqttClientOptionsBuilder()
              .WithAutoReconnectDelay(TimeSpan.FromSeconds(3))
              .WithClientOptions(opt =>
              {
                  opt.WithKeepAlivePeriod(TimeSpan.FromSeconds(3));
                  opt.WithClientId(Guid.NewGuid().ToString());
                  opt.WithWebSocketServer("localhost:5000/mqtt");
              }).Build();
            managedMqttClient = new MqttFactory().CreateManagedMqttClient();
            managedMqttClient.StartAsync(options);
        }

        public async Task Publish(byte[] data, string deviceInputOutputId)
        {
            if (!managedMqttClient.IsStarted)
            {
                await managedMqttClient.StartAsync(options);
            }

            await managedMqttClient.PublishAsync(new ManagedMqttApplicationMessage
            {
                ApplicationMessage = new MqttApplicationMessage
                {
                    Topic = $"dev/outputmessage/{deviceInputOutputId}",
                    Payload = data
                }
            });
        }



        public async Task Publish(byte[] data, string systemIOGuid, string systemIOType)
        {
            if (!managedMqttClient.IsStarted)
            {
                await managedMqttClient.StartAsync(options);
            }

            await managedMqttClient.PublishAsync(new ManagedMqttApplicationMessage
            {
                ApplicationMessage = new MqttApplicationMessage
                {
                    Topic = $"dev/{systemIOGuid}/{systemIOType}",
                    Payload = data
                }
            });
        }

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {

            return Task.CompletedTask;
        }


    }
}