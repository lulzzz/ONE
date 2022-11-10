using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class OutputNodeAudit
    {
        public Guid OutputNodeAuditGuid { get; set; }
        public Guid? OutputNodeGuid { get; set; }
        public int? OutputNodeTypeCode { get; set; }
        public Guid? CustomerLocationSectionGuid { get; set; }
        public int? ApplicationTypeCode { get; set; }
        public string OutputNodeConfigurationDataXml { get; set; }
        public int? StatusTypeCode { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
