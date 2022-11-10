using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemHealthDashboardCache
    {
        public Guid SystemHealthDashboardCacheGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public int EventTypeCode { get; set; }
        public DateTime ActivationDateTime { get; set; }

        public virtual EventType EventTypeCodeNavigation { get; set; }
        public virtual Initiator InitiatorGu { get; set; }
    }
}
