using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class UserSystemConfiguration
    {
        public Guid SystemUserGuid { get; set; }
        public string DashboardFilterConfigurationDataXml { get; set; }

        public virtual SystemUser SystemUserGu { get; set; }
    }
}
