using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplicationTypeEventTypeAliasConfiguration
    {
        public ApplicationTypeEventTypeAliasConfiguration()
        {
            ApplicationTypeEventTypeAliasConfigurationDetails = new HashSet<ApplicationTypeEventTypeAliasConfigurationDetail>();
        }

        public Guid ApplicationTypeEventTypeAliasConfigurationGuid { get; set; }
        public string Name { get; set; }
        public int ApplicationTypeCode { get; set; }
        public bool IsActive { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual ICollection<ApplicationTypeEventTypeAliasConfigurationDetail> ApplicationTypeEventTypeAliasConfigurationDetails { get; set; }
    }
}
