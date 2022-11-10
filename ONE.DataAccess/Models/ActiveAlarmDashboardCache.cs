using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveAlarmDashboardCache
    {
        public Guid ActiveAlarmDashboardCacheGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public int EventTypeCode { get; set; }
        public DateTime ActivationDateTime { get; set; }
        public string LocationName { get; set; }

        public virtual EventType EventTypeCodeNavigation { get; set; }
        public virtual Initiator InitiatorGu { get; set; }
    }
}
