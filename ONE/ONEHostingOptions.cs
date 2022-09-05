using System;

namespace ONE
{
    internal class ONEHostingOptions
    {
        public HostMode Mode { get; set; } = HostMode.OnPrem;
        public CloudServices Services { get; set; } = CloudServices.All;
    }

    internal enum HostMode
    {
        OnPrem, // hosting on premise
        Cloud, // hosting in the cloud
        CloudLocal // simulating hosting in cloud but with local clustering
    }

    [Flags]
    internal enum CloudServices : byte
    {
        WebGateway = 1 << 0,
        Silo = 1 << 1,
        All = 0xFF
    }
}
