using System;

namespace ONE.Models.Domain
{
    /// <summary>
    /// A generic object to represent a broadcasted event in our SignalR hubs
    /// </summary>
    public class ChannelEventInfo
    {

        /// <summary>
        /// The name of the event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the channel the event is associated with
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// The date/time that the event was created
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The date/time that the event was created
        /// </summary>
        public DateTime CurrentServerTime { get; set; }

        public long CurrentServerTimeUTCMilliseconds { get; set; }


        /// <summary>
        /// The data associated with the event
        /// </summary>
        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
                //this.Json = JsonConvert.SerializeObject(_data, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
        }
        private object _data;

        /// <summary>
        /// A JSON representation of the event data. This is set automatically
        /// when the Data property is assigned.
        /// </summary>
        public string Json { get; private set; }

        public Guid InitiatorGuid { get; set; }

        public ChannelEventInfo()
        {
            Timestamp = DateTimeOffset.Now;
        }
        public Guid GlobalTrackingGuid { get; set; }
    }
}
