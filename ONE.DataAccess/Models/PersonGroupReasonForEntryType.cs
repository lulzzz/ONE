using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonGroupReasonForEntryType
    {
        public Guid PersonGroupGuid { get; set; }
        public int ReasonForEntryTypeCode { get; set; }
    }
}
