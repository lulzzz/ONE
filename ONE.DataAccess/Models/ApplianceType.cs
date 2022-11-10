using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplianceType
    {
        public ApplianceType()
        {
            Appliances = new HashSet<Appliance>();
            ProvisionOptionApplianceTypeCodeSystemInputs = new HashSet<ProvisionOptionApplianceTypeCodeSystemInput>();
            ProvisionOptionApplianceTypeCodeSystemOutputs = new HashSet<ProvisionOptionApplianceTypeCodeSystemOutput>();
        }

        public int ApplianceTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual ICollection<ProvisionOptionApplianceTypeCodeSystemInput> ProvisionOptionApplianceTypeCodeSystemInputs { get; set; }
        public virtual ICollection<ProvisionOptionApplianceTypeCodeSystemOutput> ProvisionOptionApplianceTypeCodeSystemOutputs { get; set; }
    }
}
