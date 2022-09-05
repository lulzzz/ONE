using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE.EdgeCompute.TransportLayer
{
    public interface IMqttTransport
    {
        void OpenMqttTransportConnection(string deviceInputOutputId);
        Task SendInputBytesToCloud(byte[] data, string deviceInputGuid, string inputOutputType);
    }
}
