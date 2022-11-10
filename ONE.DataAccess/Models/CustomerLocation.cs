using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class CustomerLocation
    {
        public CustomerLocation()
        {
            Appliances = new HashSet<Appliance>();
            CustomerLocationSections = new HashSet<CustomerLocationSection>();
            PersonGroups = new HashSet<PersonGroup>();
            SystemUsers = new HashSet<SystemUser>();
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
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual ICollection<CustomerLocationSection> CustomerLocationSections { get; set; }
        public virtual ICollection<PersonGroup> PersonGroups { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
