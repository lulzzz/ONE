using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ActiveEventFlowExecutionTracking
    {
        public Guid ActiveEventFlowExecutionTrackingGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public Guid EventFlowGuid { get; set; }
        public int EventTypeCode { get; set; }
        public string EventFlowXml { get; set; }
        public string EventFlowState { get; set; }
        public Guid? GlobalTrackingGuid { get; set; }
        public Guid? EventInstanceGuid { get; set; }
        public string EventData { get; set; }
        public Guid? TriggeredByEventFlowInstanceGuid { get; set; }
        public string EventFlowLogDetailXml { get; set; }
        public Guid? HaltedByEventFlowInstanceGuid { get; set; }
        public bool StopAudioOnEventFlowHalt { get; set; }

        public virtual EventFlow EventFlowGu { get; set; }
        public virtual EventType EventTypeCodeNavigation { get; set; }
        public virtual Initiator InitiatorGu { get; set; }
    }
}
