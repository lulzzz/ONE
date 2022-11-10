using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TemperatureTerminalPersonBatchDetail
    {
        public Guid TemperatureTerminalPersonBatchDetailGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PersonGroupGuid { get; set; }
        public string ReferenceImageBase64 { get; set; }
        public Guid TemperatureTerminalPersonBatchGuid { get; set; }
        public bool IsSyncedWithTemperatureTerminal { get; set; }
        public string SyncError { get; set; }
        public string PhoneNumber { get; set; }

        public virtual PersonGroup PersonGroupGu { get; set; }
        public virtual TemperatureTerminalPersonBatch TemperatureTerminalPersonBatchGu { get; set; }
    }
}
