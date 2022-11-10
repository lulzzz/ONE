using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class InitiatorAudit
    {
        public Guid InitiatorAuditGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public int InitiatorTypeCode { get; set; }
        public Guid CustomerLocationSectionGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public Guid EventFlowGuid { get; set; }
        public string InitiatorConfigurationDataXml { get; set; }
        public int? StatusTypeCode { get; set; }
        public string InitiatorOperationalDataXml { get; set; }
        public Guid? ApplicationTypeEventTypeAliasConfigurationGuid { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
