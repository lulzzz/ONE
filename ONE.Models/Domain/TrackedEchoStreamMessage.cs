using System;

namespace ONE.Models.Domain
{
    public class TrackedEchoStreamMessage
    {
        public EchoStreamMessage EchoStreamMessage { get; set; }
        public DateTime TimeToPublish { get; set; }
        public DateTime PublishedTime { get; set; }



        public TrackedEchoStreamMessage()
        {
        }
    }
}
