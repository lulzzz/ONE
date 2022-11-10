using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventFlowAudit
    {
        public Guid EventFlowAuditGuid { get; set; }
        public Guid? EventFlowGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventFlowXml { get; set; }
        public bool? IsActive { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
