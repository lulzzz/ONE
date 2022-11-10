using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class TemperatureDetectorEventLog
    {
        public Guid TemperatureDetectorEventLogGuid { get; set; }
        public Guid InitiatorGuid { get; set; }
        public DateTime? DateTime { get; set; }
        public string InternalTemperature { get; set; }
        public string ExternalTemperature { get; set; }

        public virtual Initiator InitiatorGu { get; set; }
    }
}
