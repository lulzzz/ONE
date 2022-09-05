using Microsoft.Extensions.Logging;
using ONE.DataAccess;
using ONE.EdgeCompute.TransportLayer;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventProcessor;
using Orleans.Concurrency;
using System;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor
{
    public class ONESystemOutputDistributorGrain : GrainBase, IONESystemOutputDistributorGrain
    {
        MqttTransportHelper _mqttTransportHelper;

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            _mqttTransportHelper = new MqttTransportHelper();
            _mqttTransportHelper.OpenMqttTransportConnection(Guid.NewGuid().ToString());
        }

        public async Task SendDataToSystemIO(byte[] payload, string systemIOId)
        {
            await _mqttTransportHelper.Publish(payload, systemIOId);
        }


        public Task OnCompletedAsync()
        {
            Logger.LogInformation("Stream completed");
            return Task.CompletedTask;
        }

        public Task OnErrorAsync(Exception ex)
        {
            Logger.LogError("Stream error");
            return Task.CompletedTask;
        }


    }
}
