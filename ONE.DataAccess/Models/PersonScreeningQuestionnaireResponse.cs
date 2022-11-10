using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonScreeningQuestionnaireResponse
    {
        public Guid PersonScreeningQuestionnaireResponseGuid { get; set; }
        public Guid PersonScreeningResultGuid { get; set; }
        public Guid ScreeningQuestionnaireGuid { get; set; }
        public bool? Response { get; set; }
        public Guid PersonGuid { get; set; }

        public virtual Person PersonGu { get; set; }
        public virtual PersonScreeningResult PersonScreeningResultGu { get; set; }
        public virtual ScreeningQuestionnaire ScreeningQuestionnaireGu { get; set; }
    }
}
