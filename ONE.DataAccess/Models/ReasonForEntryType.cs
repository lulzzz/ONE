using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ReasonForEntryType
    {
        public ReasonForEntryType()
        {
            PersonGroupFahrenheits = new HashSet<PersonGroupFahrenheit>();
            PersonPreScreeningResponses = new HashSet<PersonPreScreeningResponse>();
            PersonScreeningResults = new HashSet<PersonScreeningResult>();
        }

        public int ReasonForEntryTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<PersonGroupFahrenheit> PersonGroupFahrenheits { get; set; }
        public virtual ICollection<PersonPreScreeningResponse> PersonPreScreeningResponses { get; set; }
        public virtual ICollection<PersonScreeningResult> PersonScreeningResults { get; set; }
    }
}
