using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveAlarmTrackingHistory
    {
        public Guid ActiveAlarmTrackingHistoryGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public Guid EventInstanceGuid { get; set; }
        public DateTime AlarmStartTime { get; set; }
        public DateTime? AlarmEndTime { get; set; }
        public int EventTypeCode { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public Guid? SaveAudioMessageGuid { get; set; }
        public Guid? AssociatedSystemUserGuid { get; set; }
        public Guid? DashboardDispositionGuid { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? ActiveAlarmUserActionTypeCode { get; set; }

        public virtual SystemUser AssociatedSystemUserGu { get; set; }
        public virtual DashboardDisposition DashboardDispositionGu { get; set; }
        public virtual EventType EventTypeCodeNavigation { get; set; }
        public virtual Initiator InitiatorGu { get; set; }
    }
}
