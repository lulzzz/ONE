using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventFlowTemplate
    {
        public Guid EventFlowTemplateCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitiatorTypeCode { get; set; }
        public int ApplicationTypeCode { get; set; }
        public string EventFlowTemplateXml { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
    }
}
