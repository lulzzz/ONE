using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class State
    {
        public State()
        {
            CustomerLocations = new HashSet<CustomerLocation>();
        }

        public int StateCode { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<CustomerLocation> CustomerLocations { get; set; }
    }
}
