using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemInputAudit
    {
        public Guid SystemInputAuditGuid { get; set; }
        public Guid? SystemInputGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SystemInputTypeCode { get; set; }
        public string SystemInputConfigurationDataXml { get; set; }
        public bool? IsActive { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
