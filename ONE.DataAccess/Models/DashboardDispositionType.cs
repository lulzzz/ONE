using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class DashboardDispositionType
    {
        public DashboardDispositionType()
        {
            DashboardDispositions = new HashSet<DashboardDisposition>();
        }

        public int DashboardDispositionTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<DashboardDisposition> DashboardDispositions { get; set; }
    }
}
