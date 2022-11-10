using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplicationTypeDefaultInitiatorType
    {
        public int ApplicationTypeCode { get; set; }
        public int InitiatorTypeCode { get; set; }
        public string Name { get; set; }
        public Guid? ApplicationTypeEventTypeAliasConfigurationGuid { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
    }
}
