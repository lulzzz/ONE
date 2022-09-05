using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONE.EdgeCompute.Factory
{
    public class ONEDeviceInputThread
    {
        public Thread DeviceInputThread { get; set; }
        public IONEDeviceInput ONEDeviceInput { get; set; }
    }
}
