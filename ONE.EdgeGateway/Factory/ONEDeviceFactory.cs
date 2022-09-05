using Microsoft.Extensions.Logging;
using ONE.Common.Utility;
using System;

namespace ONE.EdgeCompute.Factory
{
    public class ONEDeviceFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        public ONEDeviceFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public IONEDeviceInput CreateDeviceInput(string inputType)
        {
            try
            {
                Type type = TypeHelper.GetFirstTypeFoundInAllAssemblies($"{inputType}Device");
                IONEDeviceInput deviceInput = (IONEDeviceInput)Activator.CreateInstance(type, new object[] { _loggerFactory });
                return deviceInput;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
