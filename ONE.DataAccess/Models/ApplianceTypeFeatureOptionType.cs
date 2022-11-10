using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ApplianceTypeFeatureOptionType
    {
        public int ApplianceTypeCode { get; set; }
        public int FeatureOptionTypeCode { get; set; }
        public bool SelectedByDefault { get; set; }
    }
}
