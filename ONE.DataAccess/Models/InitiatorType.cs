using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class InitiatorType
    {
        public InitiatorType()
        {
            ApplicationTypeDefaultInitiatorTypes = new HashSet<ApplicationTypeDefaultInitiatorType>();
            BlocklyBlockApplicationTypeInitiatorTypes = new HashSet<BlocklyBlockApplicationTypeInitiatorType>();
            EventFlowApplicationTypeInitiatorTypes = new HashSet<EventFlowApplicationTypeInitiatorType>();
            EventFlowTemplates = new HashSet<EventFlowTemplate>();
            Initiators = new HashSet<Initiator>();
            ProductTypeInitiatorTypeProvisionInterpreters = new HashSet<ProductTypeInitiatorTypeProvisionInterpreter>();
            ApplicationTypeCodes = new HashSet<ApplicationType>();
            EventTypeCodes = new HashSet<EventType>();
        }

        public int InitiatorTypeCode { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int ProtocolTypecode { get; set; }
        public int? CheckInWindowMinutes { get; set; }
        public string Name { get; set; }
        public int? EventInterpreterTypeCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemDefined { get; set; }

        public virtual ICollection<ApplicationTypeDefaultInitiatorType> ApplicationTypeDefaultInitiatorTypes { get; set; }
        public virtual ICollection<BlocklyBlockApplicationTypeInitiatorType> BlocklyBlockApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<EventFlowTemplate> EventFlowTemplates { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }
        public virtual ICollection<ProductTypeInitiatorTypeProvisionInterpreter> ProductTypeInitiatorTypeProvisionInterpreters { get; set; }

        public virtual ICollection<ApplicationType> ApplicationTypeCodes { get; set; }
        public virtual ICollection<EventType> EventTypeCodes { get; set; }
    }
}
