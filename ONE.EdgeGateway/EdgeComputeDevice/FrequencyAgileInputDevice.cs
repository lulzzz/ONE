using Microsoft.Extensions.Logging;
using MQTTnet.Extensions.ManagedClient;
using ONE.EdgeCompute.Factory;
using ONE.EdgeCompute.TransportLayer;
using System;
using System.Text;

namespace ONE.EdgeCompute.EdgeComputeDevice
{
    public class FrequencyAgileInputDevice : ONEDeviceInput
    {
        private Guid _deviceInputGuid;
        private Guid _deviceOutputGuid;
        private string _comPort;
        public readonly ILogger<FrequencyAgileInputDevice> _logger;

        //This is buffer that is used to store data from the COM port.  
        IManagedMqttClient managedMqttClient;

        public FrequencyAgileInputDevice(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FrequencyAgileInputDevice>();
        }

        public override async void Initialize(Guid deviceInputGuid, Guid deviceOutputGuid, string oneDeviceInputConfigurationData)
        {
            _deviceInputGuid = deviceInputGuid;
            _deviceOutputGuid = deviceOutputGuid;
            _comPort = oneDeviceInputConfigurationData;
            managedMqttClient = await MqttTransport.GetMqttTransportClient(_deviceInputGuid.ToString());

        }

        public async override void Start()
        {
            System.Threading.Thread.Sleep(60000);
            string text = "ONE 4.0";
        
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            await MqttTransport.SendInputBytesToCloud(bytes, bytes.ToString(), managedMqttClient);

        }
        public override void Stop()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
