using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SurveyQuestionnaire
    {
        public SurveyQuestionnaire()
        {
            PersonSurveyQuestionnaireResponses = new HashSet<PersonSurveyQuestionnaireResponse>();
        }

        public Guid SurveyQuestionnaireGuid { get; set; }
        public Guid EventFlowGuid { get; set; }
        public bool? IsActive { get; set; }
        public string QuestionDescription { get; set; }
        public int? Priority { get; set; }

        public virtual EventFlow EventFlowGu { get; set; }
        public virtual ICollection<PersonSurveyQuestionnaireResponse> PersonSurveyQuestionnaireResponses { get; set; }
    }
}
