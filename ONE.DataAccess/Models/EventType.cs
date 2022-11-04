using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventType
    {
        public EventType()
        {
            ActiveEventFlowExecutionTrackings = new HashSet<ActiveEventFlowExecutionTracking>();
        }

        public int EventTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int? OpposingEventTypeCode { get; set; }
        public bool? KeepEventFlowActive { get; set; }
        public bool? CreateEventFlowWhenNotWired { get; set; }

        public virtual ICollection<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
    }
}
