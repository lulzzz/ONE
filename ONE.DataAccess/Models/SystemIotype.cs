using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemIotype
    {
        public SystemIotype()
        {
            SystemIos = new HashSet<SystemIo>();
        }

        public int SystemIotypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int SystemIobaseTypeCode { get; set; }

        public virtual SystemIobaseType SystemIobaseTypeCodeNavigation { get; set; }
        public virtual ICollection<SystemIo> SystemIos { get; set; }
    }
}
