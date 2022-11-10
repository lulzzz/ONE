using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProvisionOption
    {
        public int ProvisionOptionCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ApplianceTypeCode { get; set; }

        public virtual ApplianceType ApplianceTypeCodeNavigation { get; set; }
    }
}
