using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class DashboardDisposition
    {
        public DashboardDisposition()
        {
            ActiveAlarmTrackingHistories = new HashSet<ActiveAlarmTrackingHistory>();
            ActiveAlarmTrackings = new HashSet<ActiveAlarmTracking>();
        }

        public Guid DashboardDispositionGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DashboardDispositionTypeCode { get; set; }

        public virtual DashboardDispositionType DashboardDispositionTypeCodeNavigation { get; set; }
        public virtual ICollection<ActiveAlarmTrackingHistory> ActiveAlarmTrackingHistories { get; set; }
        public virtual ICollection<ActiveAlarmTracking> ActiveAlarmTrackings { get; set; }
    }
}
