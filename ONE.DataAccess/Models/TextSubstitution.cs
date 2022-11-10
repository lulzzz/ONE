using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TextSubstitution
    {
        public Guid TextSubstitutionGuid { get; set; }
        public string OriginalText { get; set; }
        public string SubstitutedText { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
