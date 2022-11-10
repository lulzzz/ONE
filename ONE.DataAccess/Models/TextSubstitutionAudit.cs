using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TextSubstitutionAudit
    {
        public Guid TextSubstitutionAuditGuid { get; set; }
        public Guid? TextSubstitutionGuid { get; set; }
        public string OriginalText { get; set; }
        public string SubstitutedText { get; set; }
        public string Activity { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
