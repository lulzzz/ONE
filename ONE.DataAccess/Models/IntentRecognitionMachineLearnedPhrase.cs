using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class IntentRecognitionMachineLearnedPhrase
    {
        public Guid IntentRecognitionMachineLearnedPhraseGuid { get; set; }
        public long? LuisphraseListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhraseList { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
