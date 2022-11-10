using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonPreScreeningQuestionnaireResponse
    {
        public Guid PersonPreScreeningQuestionnaireResponseGuid { get; set; }
        public Guid PersonPreScreeningResponseGuid { get; set; }
        public Guid ScreeningQuestionnaireGuid { get; set; }
        public bool Response { get; set; }

        public virtual PersonPreScreeningResponse PersonPreScreeningResponseGu { get; set; }
        public virtual ScreeningQuestionnaire ScreeningQuestionnaireGu { get; set; }
    }
}
