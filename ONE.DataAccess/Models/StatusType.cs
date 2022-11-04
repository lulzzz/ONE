using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class StatusType
    {
        public StatusType()
        {
            Initiators = new HashSet<Initiator>();
        }

        public int StatusTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Initiator> Initiators { get; set; }
    }
}
