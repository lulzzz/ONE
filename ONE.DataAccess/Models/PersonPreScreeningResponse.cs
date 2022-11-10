using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonPreScreeningResponse
    {
        public PersonPreScreeningResponse()
        {
            PersonPreScreeningQuestionnaireResponses = new HashSet<PersonPreScreeningQuestionnaireResponse>();
        }

        public Guid PersonPreScreeningResponseGuid { get; set; }
        public Guid? PersonAccountGuid { get; set; }
        public int? ReasonForEntryTypeCode { get; set; }
        public string EntryDetail { get; set; }
        public DateTime? LastPreScreeningDateTime { get; set; }
        public Guid? PersonPreScreeningAccountGuid { get; set; }

        public virtual ReasonForEntryType ReasonForEntryTypeCodeNavigation { get; set; }
        public virtual ICollection<PersonPreScreeningQuestionnaireResponse> PersonPreScreeningQuestionnaireResponses { get; set; }
    }
}
