using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class CustomScreen
    {
        public CustomScreen()
        {
            ActiveCustomScreenFragmentCaches = new HashSet<ActiveCustomScreenFragmentCache>();
            FragmentLogs = new HashSet<FragmentLog>();
        }

        public Guid CustomScreenGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ScreenConfigurationXml { get; set; }
        public string FragmentConfigurationXml { get; set; }
        public string StyleConfigurationXml { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CustomScreenType { get; set; }

        public virtual ICollection<ActiveCustomScreenFragmentCache> ActiveCustomScreenFragmentCaches { get; set; }
        public virtual ICollection<FragmentLog> FragmentLogs { get; set; }
    }
}
