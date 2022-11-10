using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemOutput
    {
        public SystemOutput()
        {
            ProvisionOptionApplianceTypeCodeSystemOutputs = new HashSet<ProvisionOptionApplianceTypeCodeSystemOutput>();
        }

        public Guid SystemOutputGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemOutputTypeCode { get; set; }
        public string SystemOutputConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsSpecialIoresource { get; set; }

        public virtual SystemOutputType SystemOutputTypeCodeNavigation { get; set; }
        public virtual ICollection<ProvisionOptionApplianceTypeCodeSystemOutput> ProvisionOptionApplianceTypeCodeSystemOutputs { get; set; }
    }
}
