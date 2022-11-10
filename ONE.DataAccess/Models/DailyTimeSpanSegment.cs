using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class DailyTimeSpanSegment
    {
        public int DailyTimeSpanSegmentCode { get; set; }
        public string SegmentName { get; set; }
        public int? SecondsPastMidnight { get; set; }
    }
}
