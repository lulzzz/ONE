using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class DashboardAlarmStateTransitionConfiguration
    {
        public Guid DashboardAlarmStateTransitionConfigurationGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public int InitiatorTypeCode { get; set; }
        public Guid? CustomerLocationSectionGuid { get; set; }
        public int? State1Period { get; set; }
        public string State1BackgroundColor { get; set; }
        public string State1Visual { get; set; }
        public Guid? State1Sound { get; set; }
        public int? State2Period { get; set; }
        public string State2BackgroundColor { get; set; }
        public string State2Visual { get; set; }
        public Guid? State2Sound { get; set; }
        public int? State3Period { get; set; }
        public string State3BackgroundColor { get; set; }
        public string State3Visual { get; set; }
        public Guid? State3Sound { get; set; }
        public string PriorityType { get; set; }
        public int? EventTypeCode { get; set; }
    }
}
