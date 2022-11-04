using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerLocations = new HashSet<CustomerLocation>();
        }

        public Guid CustomerGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MarketTypeCode { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerLogo { get; set; }

        public virtual MarketType MarketTypeCodeNavigation { get; set; }
        public virtual ICollection<CustomerLocation> CustomerLocations { get; set; }
    }
}
