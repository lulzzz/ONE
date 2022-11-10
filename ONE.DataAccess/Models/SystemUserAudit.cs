using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemUserAudit
    {
        public Guid SystemUserAuditGuid { get; set; }
        public Guid? SystemUserGuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? UserRoleTypeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsActive { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
