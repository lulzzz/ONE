using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProvisionOptionApplianceTypeEventFlow
    {
        public int ProvisionOptionCode { get; set; }
        public int ApplianceTypeCode { get; set; }
        public Guid EventFlowGuid { get; set; }

        public virtual EventFlow EventFlowGu { get; set; }
    }
}
