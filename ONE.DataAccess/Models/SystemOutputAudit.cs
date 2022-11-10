using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemOutputAudit
    {
        public Guid SystemOutputAuditGuid { get; set; }
        public Guid? SystemOutputGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SystemOutputTypeCode { get; set; }
        public string SystemOutputConfigurationDataXml { get; set; }
        public bool? IsActive { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
