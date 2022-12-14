using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventFlow
    {
        public EventFlow()
        {
            ActiveEventFlowExecutionTrackings = new HashSet<ActiveEventFlowExecutionTracking>();
            EventFlowApplicationTypeInitiatorTypes = new HashSet<EventFlowApplicationTypeInitiatorType>();
            Initiators = new HashSet<Initiator>();
            ProvisionOptionApplianceTypeEventFlows = new HashSet<ProvisionOptionApplianceTypeEventFlow>();
            SurveyQuestionnaires = new HashSet<SurveyQuestionnaire>();
        }

        public Guid EventFlowGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventFlowXml { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDoubleLocked { get; set; }
        public bool IsEnterprise { get; set; }

        public virtual ICollection<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
        public virtual ICollection<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }
        public virtual ICollection<ProvisionOptionApplianceTypeEventFlow> ProvisionOptionApplianceTypeEventFlows { get; set; }
        public virtual ICollection<SurveyQuestionnaire> SurveyQuestionnaires { get; set; }
    }
}
