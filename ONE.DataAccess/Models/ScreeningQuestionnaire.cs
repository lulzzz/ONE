using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ScreeningQuestionnaire
    {
        public ScreeningQuestionnaire()
        {
            PersonPreScreeningQuestionnaireResponses = new HashSet<PersonPreScreeningQuestionnaireResponse>();
            PersonScreeningQuestionnaireResponses = new HashSet<PersonScreeningQuestionnaireResponse>();
        }

        public Guid ScreeningQuestionnaireGuid { get; set; }
        public string QuestionDescription { get; set; }
        public int? Priority { get; set; }
        public bool? IsActive { get; set; }
        public string PassAnswer { get; set; }
        public string BadgeIndicator { get; set; }

        public virtual ICollection<PersonPreScreeningQuestionnaireResponse> PersonPreScreeningQuestionnaireResponses { get; set; }
        public virtual ICollection<PersonScreeningQuestionnaireResponse> PersonScreeningQuestionnaireResponses { get; set; }
    }
}
