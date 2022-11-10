using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveAlarmUserActionTracking
    {
        public Guid ActiveAlarmUserActionTrackingGuid { get; set; }
        public Guid ActiveAlarmTrackingGuid { get; set; }
        public int ActiveAlarmUserActionTypeCode { get; set; }
        public Guid? AssociatedSystemUserGuid { get; set; }

        public virtual ActiveAlarmTracking ActiveAlarmTrackingGu { get; set; }
        public virtual ActiveAlarmUserActionType ActiveAlarmUserActionTypeCodeNavigation { get; set; }
        public virtual SystemUser AssociatedSystemUserGu { get; set; }
    }
}
