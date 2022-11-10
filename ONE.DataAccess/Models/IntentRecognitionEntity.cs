using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class IntentRecognitionEntity
    {
        public Guid IntentRecognitionEntityGuid { get; set; }
        public Guid? LuisentityGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IntentRecognitionEntityTypeCode { get; set; }
        public Guid? ParentIntentRecognitionEntityGuid { get; set; }
        public string EntityConfigurationDataXml { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual IntentRecognitionEntityType IntentRecognitionEntityTypeCodeNavigation { get; set; }
    }
}
