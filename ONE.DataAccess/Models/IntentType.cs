using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class IntentType
    {
        public IntentType()
        {
            IntentConfigurations = new HashSet<IntentConfiguration>();
        }

        public int IntentTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<IntentConfiguration> IntentConfigurations { get; set; }
    }
}
