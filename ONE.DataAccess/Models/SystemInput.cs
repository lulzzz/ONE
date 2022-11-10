using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemInput
    {
        public SystemInput()
        {
            ProvisionOptionApplianceTypeCodeSystemInputs = new HashSet<ProvisionOptionApplianceTypeCodeSystemInput>();
        }

        public Guid SystemInputGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemInputTypeCode { get; set; }
        public string SystemInputConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual SystemInputType SystemInputTypeCodeNavigation { get; set; }
        public virtual ICollection<ProvisionOptionApplianceTypeCodeSystemInput> ProvisionOptionApplianceTypeCodeSystemInputs { get; set; }
    }
}
