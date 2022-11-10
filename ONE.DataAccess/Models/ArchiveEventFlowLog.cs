using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ArchiveEventFlowLog
    {
        public Guid EventFlowLogGuid { get; set; }
        public Guid EventFlowGuid { get; set; }
        public Guid EventInstanceGuid { get; set; }
        public int EventTypeCode { get; set; }
        public DateTime EventFlowStartUtc { get; set; }
        public DateTime? EventFlowEndUtc { get; set; }
        public int? EventFlowCompletionTypeCode { get; set; }
        public Guid? HaltedByEventFlowInstanceGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public Guid LocationSectionGuid { get; set; }
        public Guid ReportAliasGuid { get; set; }
        public Guid? TriggeredByEventFlowInstanceGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public string EventData { get; set; }
    }
}
