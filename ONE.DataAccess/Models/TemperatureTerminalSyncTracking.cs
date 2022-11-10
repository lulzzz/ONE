using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TemperatureTerminalSyncTracking
    {
        public Guid TemperatureTerminalSyncTrackingGuid { get; set; }
        public Guid ApplianceGuid { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string EventData { get; set; }
        public bool IsSyncedWithTemperatureTerminal { get; set; }
        public string SyncError { get; set; }

        public virtual Appliance ApplianceGu { get; set; }
    }
}
