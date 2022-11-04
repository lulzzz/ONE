using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemIobaseType
    {
        public SystemIobaseType()
        {
            SystemIotypes = new HashSet<SystemIotype>();
        }

        public int SystemIobaseTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<SystemIotype> SystemIotypes { get; set; }
    }
}
