using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PccDispositionSyncTracking
    {
        public Guid PccDispositionSyncTrackingGuid { get; set; }
        public Guid ActiveAlarmTrackingGuid { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string PccDispositionJsonData { get; set; }
        public bool IsSyncedWithPcc { get; set; }
        public int? PccProgressNoteId { get; set; }
        public string PccSyncError { get; set; }
    }
}
