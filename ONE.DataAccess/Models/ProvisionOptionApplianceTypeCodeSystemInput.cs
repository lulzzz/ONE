using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProvisionOptionApplianceTypeCodeSystemInput
    {
        public int ProvisionOptionCode { get; set; }
        public int ApplianceTypeCode { get; set; }
        public Guid SystemInputGuid { get; set; }

        public virtual ApplianceType ApplianceTypeCodeNavigation { get; set; }
        public virtual SystemInput SystemInputGu { get; set; }
    }
}
