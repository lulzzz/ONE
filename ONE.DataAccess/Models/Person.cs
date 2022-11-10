using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonFahrenheits = new HashSet<PersonFahrenheit>();
            PersonScreeningQuestionnaireResponses = new HashSet<PersonScreeningQuestionnaireResponse>();
            PersonSurveyQuestionnaireResponses = new HashSet<PersonSurveyQuestionnaireResponse>();
        }

        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PersonGroupGuid { get; set; }
        public string ReferenceImageBase64 { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UniqueId { get; set; }

        public virtual PersonGroup PersonGroupGu { get; set; }
        public virtual ICollection<PersonFahrenheit> PersonFahrenheits { get; set; }
        public virtual ICollection<PersonScreeningQuestionnaireResponse> PersonScreeningQuestionnaireResponses { get; set; }
        public virtual ICollection<PersonSurveyQuestionnaireResponse> PersonSurveyQuestionnaireResponses { get; set; }
    }
}
