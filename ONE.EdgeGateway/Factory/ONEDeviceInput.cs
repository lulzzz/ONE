using System;

namespace ONE.EdgeCompute.Factory
{
   public abstract class ONEDeviceInput : IONEDeviceInput
    {

        public string ONEDeviceName { get; set; }
        public string ONEDeviceInputTypeName { get; set; }
        public Guid ONEDeviceInputGUID { get; set; }
        public Guid ONEDeviceOutputGUID { get; set; }
        public abstract void Initialize(Guid deviceInputGuid, Guid deviceOutputGuid,string oneDeviceInputConfigurationData);
        public abstract void Start();
        public abstract void Stop();
        public abstract void Dispose();

    }
}
