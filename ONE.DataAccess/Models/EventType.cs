using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventType
    {
        public EventType()
        {
            ActiveAlarmDashboardCaches = new HashSet<ActiveAlarmDashboardCache>();
            ActiveAlarmTrackingHistories = new HashSet<ActiveAlarmTrackingHistory>();
            ActiveAlarmTrackings = new HashSet<ActiveAlarmTracking>();
            ActiveEventFlowExecutionTrackings = new HashSet<ActiveEventFlowExecutionTracking>();
            ApplicationTypeEventTypeAliasConfigurationDetails = new HashSet<ApplicationTypeEventTypeAliasConfigurationDetail>();
            SystemHealthDashboardCaches = new HashSet<SystemHealthDashboardCache>();
            InitiatorTypeCodes = new HashSet<InitiatorType>();
        }

        public int EventTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int? OpposingEventTypeCode { get; set; }
        public bool? KeepEventFlowActive { get; set; }
        public bool? CreateEventFlowWhenNotWired { get; set; }

        public virtual ICollection<ActiveAlarmDashboardCache> ActiveAlarmDashboardCaches { get; set; }
        public virtual ICollection<ActiveAlarmTrackingHistory> ActiveAlarmTrackingHistories { get; set; }
        public virtual ICollection<ActiveAlarmTracking> ActiveAlarmTrackings { get; set; }
        public virtual ICollection<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
        public virtual ICollection<ApplicationTypeEventTypeAliasConfigurationDetail> ApplicationTypeEventTypeAliasConfigurationDetails { get; set; }
        public virtual ICollection<SystemHealthDashboardCache> SystemHealthDashboardCaches { get; set; }

        public virtual ICollection<InitiatorType> InitiatorTypeCodes { get; set; }
    }
}
