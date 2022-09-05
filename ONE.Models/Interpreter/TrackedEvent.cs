using ONE.Models.Enumerations;
using System;

namespace ONE.Models.Interpeter
{
    public class TrackedEvent
    {
        public Guid EventInstanceGUID { get; set; }
        public EventType EventType { get; set; }
        public DateTime PublishedDateTimeUTC { get; set; }

    }
}
