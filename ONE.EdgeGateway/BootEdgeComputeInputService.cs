using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ONE.DataAccess;
using ONE.EdgeCompute.Factory;
using ONE.EdgeCompute.TransportLayer;
using ONE.Models.Domain;
using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ONE.EdgeCompute
{

    // This service would be used normally to discover all the edge device inputs that need to be created.
    // for local installment this might, this could happen by querying the OdinSupervisor via the Web Gateway
    public class BootEdgeComputeInputService : BackgroundService
    {
        //private readonly MqttTransport _transport;
        private readonly ILogger _logger;
        private Dictionary<Guid, ONEDeviceInputThread> _oneDeviceInputThreads { get; set; }
        ILoggerFactory _loggerFactory;
        public BootEdgeComputeInputService(ILogger<BootEdgeComputeInputService> logger, ILoggerFactory loggerFactory)
        {
            // _transport = clientTransport;
            _loggerFactory = loggerFactory;
            _logger = logger;
            _oneDeviceInputThreads = new Dictionary<Guid, ONEDeviceInputThread>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            // for now just simulate sending some data 
            _logger.LogInformation("Started Boot Edge Compute Inputs Service");

            DeviceInputOuputRepository deviceInputOuputRepository = new DeviceInputOuputRepository();
            List<DeviceInputOutputInfo> deviceInputOutputInfos = deviceInputOuputRepository.GetDeviceInputOutputInfo();
            foreach (DeviceInputOutputInfo deviceInputOutputInfo in deviceInputOutputInfos)
            {
                CreateNewDeviceInputThread(deviceInputOutputInfo);
            }
            return;
        }


        private void CreateNewDeviceInputThread(DeviceInputOutputInfo deviceInputOutputInfo)
        {


            ONEDeviceFactory oneDeviceFactory = new ONEDeviceFactory(_loggerFactory);

            IONEDeviceInput oneDeviceInput = oneDeviceFactory.CreateDeviceInput(deviceInputOutputInfo.DeviceInputOutputType);
            oneDeviceInput.ONEDeviceInputGUID = deviceInputOutputInfo.DeviceInputGuid;
            oneDeviceInput.ONEDeviceName = deviceInputOutputInfo.DeviceName;
            oneDeviceInput.ONEDeviceOutputGUID = deviceInputOutputInfo.DeviceOutputGuid;
            oneDeviceInput.Initialize(deviceInputOutputInfo.DeviceInputGuid, deviceInputOutputInfo.DeviceOutputGuid, deviceInputOutputInfo.COMPort);

            Thread deviceInputCaller = new Thread(new ThreadStart(oneDeviceInput.Start));  //https://msdn.microsoft.com/en-us/library/ts553s52(v=vs.110).aspx -- Thread reference
            deviceInputCaller.Name = $"{oneDeviceInput.ONEDeviceName}_{oneDeviceInput.ONEDeviceInputGUID.ToString()}";//There can be more than one System input of same type, so each thread can be named with SystemInputName_Guid
            deviceInputCaller.Start();

            _oneDeviceInputThreads.Add(oneDeviceInput.ONEDeviceInputGUID, new ONEDeviceInputThread
            {
                ONEDeviceInput = oneDeviceInput,
                DeviceInputThread = deviceInputCaller
            });
        }
    }
}
