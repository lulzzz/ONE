using Newtonsoft.Json;
using System;

namespace ONE.Models.Domain
{
    public class DashboardEventInfo
    {
        public string EventType { get; set; }
        public DateTime ActivationTime { get; set; }
        public long ActivationTimeUTCMilliseconds { get; set; }
        public string LocationSectionName { get; set; }
        public string EventTypeAlias { get; set; }
        public Guid CustomerLocationGuid { get; set; }
        public string CustomerLocationName { get; set; }
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// The date/time that the event was created
        /// </summary>
        public DateTime CurrentServerTime { get; set; }

        public long CurrentServerTimeUTCMilliseconds { get; set; }
        /// <summary>
        /// Gets or sets the dashboard initiator.
        /// </summary>
        /// <value>
        /// The dashboard initiator.
        /// </value>
        [JsonProperty("initiatorInfo")]
        public InitiatorInfo InitiatorInfo { get; set; }
        public bool IsClearEvent { get; set; }
    }
}
