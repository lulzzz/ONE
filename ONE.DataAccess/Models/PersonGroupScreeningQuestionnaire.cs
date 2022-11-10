using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonGroupScreeningQuestionnaire
    {
        public Guid PersonGroupGuid { get; set; }
        public Guid ScreeningQuestionnaireGuid { get; set; }
    }
}
