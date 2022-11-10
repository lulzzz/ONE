using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonScreeningResult
    {
        public PersonScreeningResult()
        {
            PersonScreeningQuestionnaireResponses = new HashSet<PersonScreeningQuestionnaireResponse>();
            PersonSurveyQuestionnaireResponses = new HashSet<PersonSurveyQuestionnaireResponse>();
        }

        public Guid PersonScreeningResultGuid { get; set; }
        public Guid? PersonGuid { get; set; }
        public string TemperatureCelsius { get; set; }
        public int ReasonForEntryTypeCode { get; set; }
        public string EntryDetail { get; set; }
        public DateTime? ScreeningDateTime { get; set; }
        public int? ScreeningStatusTypeCode { get; set; }
        public Guid? ApplianceGuid { get; set; }
        public string ReferenceImageBase64 { get; set; }
        public DateTime? ExitScreeningDateTime { get; set; }

        public virtual ReasonForEntryType ReasonForEntryTypeCodeNavigation { get; set; }
        public virtual ScreeningStatusType ScreeningStatusTypeCodeNavigation { get; set; }
        public virtual ICollection<PersonScreeningQuestionnaireResponse> PersonScreeningQuestionnaireResponses { get; set; }
        public virtual ICollection<PersonSurveyQuestionnaireResponse> PersonSurveyQuestionnaireResponses { get; set; }
    }
}
