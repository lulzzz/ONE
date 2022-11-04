using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemIo
    {
        public Guid SystemIoguid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemIotypeCode { get; set; }
        public string SystemIoconfigurationDataXml { get; set; }
        public bool IsActive { get; set; }

        public virtual SystemIotype SystemIotypeCodeNavigation { get; set; }
    }
}
