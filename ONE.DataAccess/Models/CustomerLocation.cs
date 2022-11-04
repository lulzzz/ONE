using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class CustomerLocation
    {
        public CustomerLocation()
        {
            CustomerLocationSections = new HashSet<CustomerLocationSection>();
        }

        public Guid CustomerLocationGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? StateCode { get; set; }
        public string ZipCode { get; set; }
        public Guid? CustomerGuid { get; set; }

        public virtual Customer CustomerGu { get; set; }
        public virtual State StateCodeNavigation { get; set; }
        public virtual ICollection<CustomerLocationSection> CustomerLocationSections { get; set; }
    }
}
