using Microsoft.Extensions.Logging;
using MQTTnet.Extensions.ManagedClient;
using ONE.EdgeCompute.Factory;
using ONE.EdgeCompute.TransportLayer;
using ONE.Models.Domain;
using RJCP.IO.Ports;
using System;
using System.Collections.Generic;

namespace ONE.EdgeCompute.EdgeComputeDevice
{
    public class EchoStreamInputDevice : ONEDeviceInput
    {
        private Guid _deviceInputGuid;
        private Guid _deviceOutputGuid;
        private string _comPort;
        public readonly ILogger<EchoStreamInputDevice> _logger;
        private SerialPortStream _listeningPort = null;


        //This is buffer that is used to store data from the COM port.  
        private byte[] _dataReceivedBuffer = new byte[8192];
        IManagedMqttClient managedMqttClient;

        public EchoStreamInputDevice(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EchoStreamInputDevice>();
        }

        public override async void Initialize(Guid deviceInputGuid, Guid deviceOutputGuid, string oneDeviceInputConfigurationData)
        {
            _deviceInputGuid = deviceInputGuid;
            _deviceOutputGuid = deviceOutputGuid;
            _comPort = oneDeviceInputConfigurationData;
            managedMqttClient = await MqttTransport.GetMqttTransportClient(_deviceInputGuid.ToString());

        }

        public override void Start()
        {
            ConfigureListeningComPort();
        }


        private void ConfigureListeningComPort()
        {
            _listeningPort = new SerialPortStream(_comPort, 9600, 8, Parity.None, StopBits.One);
            _listeningPort.DataReceived += listeningPort_DataReceived;
            _listeningPort.ErrorReceived += listeningPort_ErrorReceived;

            if (!_listeningPort.IsOpen)
            {
                _listeningPort.Open();
            }
        }

        private async void listeningPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {


                //Declare the number of bytes read
                int bytesRead;

                //Create the data read buffer
                byte[] dataReadBuffer = new byte[bytesRead = 0];

                //Initialize a list of echostream messages to publish
                List<EchoStreamMessage> candidateEchoStreamMessagesToPublish = new List<EchoStreamMessage>();

                //Loop until all of the bytes are read in the serial stream buffer
                do
                {
                    //Read the bytes into the data received buffer
                    bytesRead = _listeningPort.Read(_dataReceivedBuffer, 0, _listeningPort.BytesToRead);

                    //Check if any bytes were read, and if so, copy them into the bytes read buffer and process those bytes
                    if (bytesRead > 0)
                    {
                        //Create the data read buffer
                        dataReadBuffer = new byte[bytesRead];

                        //Copy the bytes from the datareceived buffer into the data read buffer
                        Array.Copy(_dataReceivedBuffer, dataReadBuffer, bytesRead);
                    }
                } while (bytesRead > 0);


                //Publish captured messages
                if (dataReadBuffer.Length > 1)
                {
                    await MqttTransport.SendInputBytesToCloud(dataReadBuffer, _deviceInputGuid.ToString(), managedMqttClient);

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void listeningPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new NotImplementedException();
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
