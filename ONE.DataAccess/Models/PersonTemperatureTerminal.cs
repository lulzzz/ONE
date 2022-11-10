using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonTemperatureTerminal
    {
        public Guid PersonGuid { get; set; }
        public string TemperatureTerminalFaceId { get; set; }
    }
}
