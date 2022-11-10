using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TemperatureTerminalPersonBatch
    {
        public TemperatureTerminalPersonBatch()
        {
            TemperatureTerminalPersonBatchDetails = new HashSet<TemperatureTerminalPersonBatchDetail>();
        }

        public Guid TemperatureTerminalPersonBatchGuid { get; set; }
        public string ZipFileName { get; set; }
        public DateTime BatchCreatedDate { get; set; }
        public bool? IsBatchCompleted { get; set; }

        public virtual ICollection<TemperatureTerminalPersonBatchDetail> TemperatureTerminalPersonBatchDetails { get; set; }
    }
}
