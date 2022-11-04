using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplicationType
    {
        public ApplicationType()
        {
            EventFlowApplicationTypeInitiatorTypes = new HashSet<EventFlowApplicationTypeInitiatorType>();
            Initiators = new HashSet<Initiator>();
            InitiatorTypeCodes = new HashSet<InitiatorType>();
        }

        public int ApplicationTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }

        public virtual ICollection<InitiatorType> InitiatorTypeCodes { get; set; }
    }
}
