using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class UserRoleType
    {
        public UserRoleType()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public int UserRoleTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
