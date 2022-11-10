using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class IntentConfiguration
    {
        public Guid IntentConfigurationGuid { get; set; }
        public Guid LuisintentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IntentTypeCode { get; set; }
        public string IntentConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual IntentType IntentTypeCodeNavigation { get; set; }
    }
}
