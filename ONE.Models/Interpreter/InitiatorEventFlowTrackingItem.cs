using System;
using System.Collections.Generic;

namespace ONE.Models.Interpeter
{
    public class InitiatorEventFlowTrackingItem
    {
        public Guid InitiatorGUID { get; set; }
        public Guid EventFlowGUID { get; set; }
        public DateTime TrackingUpdatedDateTimeUTC { get; set; }
        public List<TrackedEvent> ActiveEvents { get; set; }

        public InitiatorEventFlowTrackingItem()
        {
            ActiveEvents = new List<TrackedEvent>();
        }
    }
}
