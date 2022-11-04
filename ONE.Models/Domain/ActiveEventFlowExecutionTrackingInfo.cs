using System;

namespace ONE.Models.Domain
{
    public class ActiveEventFlowExecutionTrackingInfo
    {
        public Guid EventFlowActivationBlockTrackGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public Guid EventFlowGuid { get; set; }
        public int EventTypeCode { get; set; }
        public string EventFlowXml { get; set; }
        public string EventFlowState { get; set; }
        public Guid GlobalTrackingGuid { get; set; }
        public Guid EventInstanceGuid { get; set; }
        public string EventData { get; set; }
        public Guid? TriggeredByEventFlowInstanceGuid { get; set; }
        public string EventFlowLogDetailXml { get; set; }
        public Guid? HaltedByEventFlowInstanceGuid { get; set; }
        public bool StopAudioOnEventFlowHalt { get; set; }

    }
}
