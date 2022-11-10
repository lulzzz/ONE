using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemOutputType
    {
        public SystemOutputType()
        {
            SystemOutputs = new HashSet<SystemOutput>();
        }

        public int SystemOutputTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int? SystemOutputCategoryTypeCode { get; set; }

        public virtual SystemOutputCategoryType SystemOutputCategoryTypeCodeNavigation { get; set; }
        public virtual ICollection<SystemOutput> SystemOutputs { get; set; }
    }
}
