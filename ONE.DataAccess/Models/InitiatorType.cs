using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class InitiatorType
    {
        public InitiatorType()
        {
            EventFlowApplicationTypeInitiatorTypes = new HashSet<EventFlowApplicationTypeInitiatorType>();
            Initiators = new HashSet<Initiator>();
            ApplicationTypeCodes = new HashSet<ApplicationType>();
        }

        public int InitiatorTypeCode { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int ProtocolTypecode { get; set; }
        public int? CheckInWindowMinutes { get; set; }
        public string Name { get; set; }
        public int? EventInterpreterTypeCode { get; set; }

        public virtual ICollection<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }

        public virtual ICollection<ApplicationType> ApplicationTypeCodes { get; set; }
    }
}
