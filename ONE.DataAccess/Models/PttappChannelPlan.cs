using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PttappChannelPlan
    {
        public PttappChannelPlan()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public Guid PttappChannelPlanGuid { get; set; }
        public string Name { get; set; }
        public string PttappChannelPlanConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
