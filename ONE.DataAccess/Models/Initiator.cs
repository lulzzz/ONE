using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class Initiator
    {
        public Initiator()
        {
            ActiveAlarmDashboardCaches = new HashSet<ActiveAlarmDashboardCache>();
            ActiveAlarmTrackingHistories = new HashSet<ActiveAlarmTrackingHistory>();
            ActiveAlarmTrackings = new HashSet<ActiveAlarmTracking>();
            ActiveEventFlowExecutionTrackings = new HashSet<ActiveEventFlowExecutionTracking>();
            FragmentLogs = new HashSet<FragmentLog>();
            SystemHealthDashboardCaches = new HashSet<SystemHealthDashboardCache>();
            TemperatureDetectorEventLogs = new HashSet<TemperatureDetectorEventLog>();
            TemperatureMonitorEventLogs = new HashSet<TemperatureMonitorEventLog>();
        }

        public Guid InitiatorGuid { get; set; }
        public int InitiatorTypeCode { get; set; }
        public Guid CustomerLocationSectionGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public Guid EventFlowGuid { get; set; }
        public string InitiatorConfigurationDataXml { get; set; }
        public int? StatusTypeCode { get; set; }
        public string InitiatorOperationalDataXml { get; set; }
        public Guid? ApplicationTypeEventTypeAliasConfigurationGuid { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDoubleLocked { get; set; }
        public bool IsEnterprise { get; set; }
        public int? MicrolocationTypeCode { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual CustomerLocationSection CustomerLocationSectionGu { get; set; }
        public virtual EventFlow EventFlowGu { get; set; }
        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
        public virtual MicrolocationType MicrolocationTypeCodeNavigation { get; set; }
        public virtual StatusType StatusTypeCodeNavigation { get; set; }
        public virtual ICollection<ActiveAlarmDashboardCache> ActiveAlarmDashboardCaches { get; set; }
        public virtual ICollection<ActiveAlarmTrackingHistory> ActiveAlarmTrackingHistories { get; set; }
        public virtual ICollection<ActiveAlarmTracking> ActiveAlarmTrackings { get; set; }
        public virtual ICollection<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
        public virtual ICollection<FragmentLog> FragmentLogs { get; set; }
        public virtual ICollection<SystemHealthDashboardCache> SystemHealthDashboardCaches { get; set; }
        public virtual ICollection<TemperatureDetectorEventLog> TemperatureDetectorEventLogs { get; set; }
        public virtual ICollection<TemperatureMonitorEventLog> TemperatureMonitorEventLogs { get; set; }
    }
}
