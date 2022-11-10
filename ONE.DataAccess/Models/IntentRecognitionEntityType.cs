using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class IntentRecognitionEntityType
    {
        public IntentRecognitionEntityType()
        {
            IntentRecognitionEntities = new HashSet<IntentRecognitionEntity>();
        }

        public int IntentRecognitionEntityTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<IntentRecognitionEntity> IntentRecognitionEntities { get; set; }
    }
}
