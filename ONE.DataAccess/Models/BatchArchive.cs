using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BatchArchive
    {
        public BatchArchive()
        {
            BatchArchiveDetails = new HashSet<BatchArchiveDetail>();
        }

        public int BatchArchiveId { get; set; }
        public int? BatchCount { get; set; }
        public string ArchiveError { get; set; }
        public DateTime? ArchiveStartTime { get; set; }
        public DateTime? ArchiveEndTime { get; set; }

        public virtual ICollection<BatchArchiveDetail> BatchArchiveDetails { get; set; }
    }
}
