using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemConfigurationType
    {
        public int SystemConfigurationTypeCode { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
    }
}
