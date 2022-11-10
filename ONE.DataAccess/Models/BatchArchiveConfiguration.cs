using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BatchArchiveConfiguration
    {
        public int BatchArchiveConfigurationId { get; set; }
        public int? NumberofDaysToArchive { get; set; }
        public int? ArchiveBatchCount { get; set; }
        public string DelayTime { get; set; }
        public bool? ContinueFlag { get; set; }
    }
}
