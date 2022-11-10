using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class KeyPerformanceIndicatorType
    {
        public Guid CustomerLocationSectionGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public int ExcellentSeconds { get; set; }
        public int FairSeconds { get; set; }
        public int PoorSeconds { get; set; }

        public virtual ApplicationType ApplicationTypeCodeNavigation { get; set; }
        public virtual CustomerLocationSection CustomerLocationSectionGu { get; set; }
    }
}
