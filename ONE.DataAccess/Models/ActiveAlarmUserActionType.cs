using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveAlarmUserActionType
    {
        public ActiveAlarmUserActionType()
        {
            ActiveAlarmUserActionTrackings = new HashSet<ActiveAlarmUserActionTracking>();
        }

        public int ActiveAlarmUserActionTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual ICollection<ActiveAlarmUserActionTracking> ActiveAlarmUserActionTrackings { get; set; }
    }
}
