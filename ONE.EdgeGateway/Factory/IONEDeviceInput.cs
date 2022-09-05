using System;

namespace ONE.EdgeCompute.Factory
{
    public interface IONEDeviceInput : IDisposable
    {
        string ONEDeviceName { get; set; }
        string ONEDeviceInputTypeName { get; set; }
        Guid ONEDeviceInputGUID { get; set; }
        Guid ONEDeviceOutputGUID { get; set; }
        void Initialize(Guid deviceInputGuid, Guid deviceOutputGuid, string oneDeviceInputConfigurationData);
        void Start();
        void Stop();

    }
}
