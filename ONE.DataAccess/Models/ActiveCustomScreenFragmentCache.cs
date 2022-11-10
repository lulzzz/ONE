using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveCustomScreenFragmentCache
    {
        public Guid ActiveCustomScreenFragmentCacheGuid { get; set; }
        public Guid CustomScreenGuid { get; set; }
        public string FragmentId { get; set; }
        public string FragmentDesignId { get; set; }
        public string FragmentAreaId { get; set; }
        public DateTime ActivationDateTime { get; set; }
        public Guid? InitiatorGuid { get; set; }
        public int? EventTypeCode { get; set; }
        public string FragmentContent { get; set; }

        public virtual CustomScreen CustomScreenGu { get; set; }
    }
}
