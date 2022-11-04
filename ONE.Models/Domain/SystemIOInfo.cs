using ONE.Models.Enumerations;
using System;

namespace ONE.Models.Domain
{
    public class SystemIOInfo
    {
        public Guid SystemIOGUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SystemIOType SystemIOType { get; set; }
        public string SystemIOConfigurationDataXML { get; set; }
        public Object ConfigurationData { get; set; }
    }
}
