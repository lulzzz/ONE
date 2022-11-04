using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class MicrolocationType
    {
        public MicrolocationType()
        {
            Initiators = new HashSet<Initiator>();
        }

        public int MicrolocationTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<Initiator> Initiators { get; set; }
    }
}
