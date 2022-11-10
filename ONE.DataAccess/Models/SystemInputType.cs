using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemInputType
    {
        public SystemInputType()
        {
            SystemInputs = new HashSet<SystemInput>();
        }

        public int SystemInputTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<SystemInput> SystemInputs { get; set; }
    }
}
