using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ReportScheduler
    {
        public Guid ReportSchedulerGuid { get; set; }
        public string Name { get; set; }
        public string ReportPath { get; set; }
        public Guid ReportId { get; set; }
        public string ScheduleType { get; set; }
        public string CustomType { get; set; }
        public string ExportType { get; set; }
        public string ParameterValues { get; set; }
        public string EmailParameter { get; set; }
        public string RecurenceInfo { get; set; }
        public int? EndAfter { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? LastRunTime { get; set; }
        public DateTime? NextRunTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
