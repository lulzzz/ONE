using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BatchArchiveDetail
    {
        public int BatchArchiveDetailId { get; set; }
        public int BatchArchiveId { get; set; }
        public Guid EventFlowLogGuid { get; set; }

        public virtual BatchArchive BatchArchive { get; set; }
    }
}
