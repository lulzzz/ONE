using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class MarketType
    {
        public MarketType()
        {
            Customers = new HashSet<Customer>();
            ApplicationTypeCodes = new HashSet<ApplicationType>();
        }

        public int MarketTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<ApplicationType> ApplicationTypeCodes { get; set; }
    }
}
