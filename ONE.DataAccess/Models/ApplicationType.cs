using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplicationType
    {
        public ApplicationType()
        {
            ApplicationTypeDefaultInitiatorTypes = new HashSet<ApplicationTypeDefaultInitiatorType>();
            ApplicationTypeEventTypeAliasConfigurations = new HashSet<ApplicationTypeEventTypeAliasConfiguration>();
            BlocklyBlockApplicationTypeInitiatorTypes = new HashSet<BlocklyBlockApplicationTypeInitiatorType>();
            EventFlowApplicationTypeInitiatorTypes = new HashSet<EventFlowApplicationTypeInitiatorType>();
            EventFlowTemplates = new HashSet<EventFlowTemplate>();
            Initiators = new HashSet<Initiator>();
            KeyPerformanceIndicatorTypes = new HashSet<KeyPerformanceIndicatorType>();
            OutputNodes = new HashSet<OutputNode>();
            InitiatorTypeCodes = new HashSet<InitiatorType>();
            MarketTypeCodes = new HashSet<MarketType>();
        }

        public int ApplicationTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSystemDefined { get; set; }

        public virtual ICollection<ApplicationTypeDefaultInitiatorType> ApplicationTypeDefaultInitiatorTypes { get; set; }
        public virtual ICollection<ApplicationTypeEventTypeAliasConfiguration> ApplicationTypeEventTypeAliasConfigurations { get; set; }
        public virtual ICollection<BlocklyBlockApplicationTypeInitiatorType> BlocklyBlockApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual ICollection<EventFlowTemplate> EventFlowTemplates { get; set; }
        public virtual ICollection<Initiator> Initiators { get; set; }
        public virtual ICollection<KeyPerformanceIndicatorType> KeyPerformanceIndicatorTypes { get; set; }
        public virtual ICollection<OutputNode> OutputNodes { get; set; }

        public virtual ICollection<InitiatorType> InitiatorTypeCodes { get; set; }
        public virtual ICollection<MarketType> MarketTypeCodes { get; set; }
    }
}
