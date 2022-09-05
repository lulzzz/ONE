using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE.EdgeCompute.TransportLayer
{
    public interface IMqttTransportHelper
    {
        void OpenMqttTransportConnection(string systemIOId);
        Task Publish(byte[] data, string systemIOId, string systemIOType);
    }
}
