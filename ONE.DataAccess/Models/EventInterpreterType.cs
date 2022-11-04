using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventInterpreterType
    {
        public int EventInterpreterTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int? ProtocolTypecode { get; set; }

        public virtual ProtocolType ProtocolTypecodeNavigation { get; set; }
    }
}
