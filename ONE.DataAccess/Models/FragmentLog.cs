using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class FragmentLog
    {
        public Guid FragmentLogGuid { get; set; }
        public int EventTypeCode { get; set; }
        public DateTime FragmentStartUtc { get; set; }
        public DateTime FragmentEndUtc { get; set; }
        public Guid LocationSectionGuid { get; set; }
        public Guid CustomScreenGuid { get; set; }
        public Guid InitiatorGuid { get; set; }

        public virtual CustomScreen CustomScreenGu { get; set; }
        public virtual Initiator InitiatorGu { get; set; }
        public virtual CustomerLocationSection LocationSectionGu { get; set; }
    }
}
