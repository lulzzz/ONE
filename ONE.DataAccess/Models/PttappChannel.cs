using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PttappChannel
    {
        public PttappChannel()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public Guid PttappChannelGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
