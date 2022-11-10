using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemContentGroup
    {
        public Guid SystemContentGroupGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CycleTimer { get; set; }
        public string SystemContentGroupConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }
    }
}
