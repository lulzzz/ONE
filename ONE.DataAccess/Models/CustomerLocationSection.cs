using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class CustomerLocationSection
    {
        public CustomerLocationSection()
        {
            Initiators = new HashSet<Initiator>();
        }

        public Guid CustomerLocationSectionGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentCustomerLocationSectionId { get; set; }
        public Guid CustomerLocationGuid { get; set; }
        public Guid? RadioChannelGuid { get; set; }
        public Guid? CapcodePlanSystemOutputGuid { get; set; }
        public bool IsActive { get; set; }
        public string ReportAs { get; set; }
        public string CustomerLocationSectionDisplayAs { get; set; }
        public string CustomerLocationSectionPronounceAs { get; set; }
        public Guid? RadioChannelGuid2 { get; set; }
        public Guid? RadioChannelGuid3 { get; set; }
        public Guid? CapcodePlanSystemOutputGuid2 { get; set; }
        public Guid? CapcodePlanSystemOutputGuid3 { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual CustomerLocation CustomerLocationGu { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }
    }
}
