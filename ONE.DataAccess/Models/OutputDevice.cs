using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class OutputDevice
    {
        public Guid OutputDeviceGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
