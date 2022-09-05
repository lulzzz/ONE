using System;

namespace ONE.Models.Domain
{
    public class SystemIOInfo
    {
        public Guid SystemIOGuid { get; set; }
        public string SystemIOName { get; set; }
        public string SystemIOType { get; set; }
        public string COMPort { get; set; }
    }
}
