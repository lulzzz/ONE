using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BaudRateType
    {
        public int BaudRateTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
    }
}
