using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ScreeningStatusType
    {
        public ScreeningStatusType()
        {
            PersonScreeningResults = new HashSet<PersonScreeningResult>();
        }

        public int ScreeningStatusTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<PersonScreeningResult> PersonScreeningResults { get; set; }
    }
}
