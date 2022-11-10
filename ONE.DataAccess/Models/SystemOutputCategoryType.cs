using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemOutputCategoryType
    {
        public SystemOutputCategoryType()
        {
            SystemOutputTypes = new HashSet<SystemOutputType>();
        }

        public int SystemOutputCategoryTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<SystemOutputType> SystemOutputTypes { get; set; }
    }
}
