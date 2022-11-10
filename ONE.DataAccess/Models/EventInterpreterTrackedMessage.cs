using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventInterpreterTrackedMessage
    {
        public Guid EventInterpreterTrackedMessageGuid { get; set; }
        public Guid EventFlowGuid { get; set; }
        public Guid EventInstanceGuid { get; set; }
        public Guid? InitiatorGuid { get; set; }
        public int EventTypeCode { get; set; }
        public Guid GlobalTrackingGuid { get; set; }
        public DateTime EventTrackedDateTime { get; set; }
        public string PayloadMessage { get; set; }
    }
}
