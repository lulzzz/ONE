using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class OutputNode
    {
        public Guid OutputNodeGuid { get; set; }
        public int OutputNodeTypeCode { get; set; }
        public Guid CustomerLocationSectionGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public string OutputNodeConfigurationDataXml { get; set; }
        public int? StatusTypeCode { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual CustomerLocationSection CustomerLocationSectionGu { get; set; }
        public virtual OutputNodeType OutputNodeTypeCodeNavigation { get; set; }
        public virtual StatusType StatusTypeCodeNavigation { get; set; }
    }
}
