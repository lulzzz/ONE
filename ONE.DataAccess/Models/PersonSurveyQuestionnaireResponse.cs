using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonSurveyQuestionnaireResponse
    {
        public Guid PersonSurveyQuestionnaireResponseGuid { get; set; }
        public Guid PersonScreeningResultGuid { get; set; }
        public Guid SurveyQuestionnaireGuid { get; set; }
        public int? PersonResponse { get; set; }
        public Guid PersonGuid { get; set; }

        public virtual Person PersonGu { get; set; }
        public virtual PersonScreeningResult PersonScreeningResultGu { get; set; }
        public virtual SurveyQuestionnaire SurveyQuestionnaireGu { get; set; }
    }
}
