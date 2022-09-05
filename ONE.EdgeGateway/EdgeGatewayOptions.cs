using System;


namespace ONE.EdgeCompute
{
    public class EdgeGatewayOptions
    {
        // for testing we will generate a random DeviceID if one is not configured via options
        public string DeviceId { get; set; } = Guid.NewGuid().ToString();

        public Transport Transport { get; set; } = Transport.WS;

        public bool Tls { get; set; } = false;
    }

    public enum Transport
    {
        TCP,
        WS,
    }
}
