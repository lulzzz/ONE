using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProvisionOptionApplianceTypeCodeSystemOutput
    {
        public int ProvisionOptionCode { get; set; }
        public int ApplianceTypeCode { get; set; }
        public Guid SystemOutputGuid { get; set; }

        public virtual ApplianceType ApplianceTypeCodeNavigation { get; set; }
        public virtual SystemOutput SystemOutputGu { get; set; }
    }
}
