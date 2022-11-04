using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventFlowApplicationTypeInitiatorType
    {
        public int ApplicationTypeCode { get; set; }
        public int InitiatorTypeCode { get; set; }
        public Guid EventFlowGuid { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual EventFlow EventFlowGu { get; set; }
        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
    }
}
