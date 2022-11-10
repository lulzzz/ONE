using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BlocklyBlockApplicationTypeInitiatorType
    {
        public int BlocklyBlockApplicationTypeInitiatorTypeCode { get; set; }
        public int IntiatorTypeCode { get; set; }
        public int ApplicationTypeCode { get; set; }
        public int InitiatorTypeCode { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
    }
}
