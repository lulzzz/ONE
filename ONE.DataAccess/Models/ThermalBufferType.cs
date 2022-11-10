using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ThermalBufferType
    {
        public int ThermalBufferTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
    }
}
