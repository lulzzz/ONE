using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using ONE.EdgeCompute.Output;
using System;
using System.Threading.Tasks;

namespace ONE.EdgeCompute.TransportLayer
{
    public class MqttTransport: IMqttTransport
    {
        protected IManagedMqttClient managedMqttClient { get; set; }
        protected ManagedMqttClientOptions options { get; set; }
        public void OpenMqttTransportConnection(string deviceInputGuid)
        {

            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
               .WithAutoReconnectDelay(TimeSpan.FromSeconds(3))
               .WithClientOptions(opt =>
               {
                   opt.WithClientId(deviceInputGuid);
                   opt.WithWebSocketServer("localhost:5000/mqtt");
               }).Build();
            managedMqttClient = new MqttFactory().CreateManagedMqttClient();
            managedMqttClient.StartAsync(options);
           
        }


        public async Task SendInputBytesToCloud(byte[] data, string deviceInputGuid,string inputOutputType)
        {

            await managedMqttClient.PublishAsync(new ManagedMqttApplicationMessage
            {
                ApplicationMessage = new MqttApplicationMessage
                {
                    Topic = $"dev/{deviceInputGuid}/{inputOutputType}",
                    Payload = data
                }
            });
        }


    }
}