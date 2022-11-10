using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class Appliance
    {
        public Appliance()
        {
            TemperatureTerminalSyncTrackings = new HashSet<TemperatureTerminalSyncTracking>();
        }

        public Guid ApplianceGuid { get; set; }
        public int ApplianceTypeCode { get; set; }
        /// <summary>
        /// This column can hold either IP Address or DNS name of Primary appliance
        /// </summary>
        public string PrimaryNetworkInfo { get; set; }
        public bool IsPrimary { get; set; }
        public string ApplianceImageVersion { get; set; }
        public string OdinComputeAppVersion { get; set; }
        public string OdinComputeDatabaseVersion { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public Guid? CustomerLocationGuid { get; set; }
        public string ApplianceIntegrationKey { get; set; }
        public bool? IsPttserver { get; set; }
        public string Name { get; set; }
        public bool? IsMe { get; set; }
        public bool IsFahrenheitServer { get; set; }

        public virtual ApplianceType ApplianceTypeCodeNavigation { get; set; }
        public virtual CustomerLocation CustomerLocationGu { get; set; }
        public virtual ICollection<TemperatureTerminalSyncTracking> TemperatureTerminalSyncTrackings { get; set; }
    }
}
