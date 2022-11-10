using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ReportPeriodType
    {
        public int ReportPeriodTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
    }
}
