using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplicationTypeEventTypeAliasConfigurationDetail
    {
        public Guid ApplicationTypeEventTypeAliasConfigurationGuid { get; set; }
        public int EventTypeCode { get; set; }
        public string Name { get; set; }

        public virtual ApplicationTypeEventTypeAliasConfiguration ApplicationTypeEventTypeAliasConfigurationGu { get; set; }
        public virtual EventType EventTypeCodeNavigation { get; set; }
    }
}
