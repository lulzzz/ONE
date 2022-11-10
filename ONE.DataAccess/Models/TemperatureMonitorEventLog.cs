using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TemperatureMonitorEventLog
    {
        public Guid TemperatureMonitorEventLogGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public DateTime? DateTime { get; set; }
        public string TemperatureAmbient { get; set; }

        public virtual Initiator InitiatorGu { get; set; }
    }
}
