using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProtocolType
    {
        public ProtocolType()
        {
            EventInterpreterTypes = new HashSet<EventInterpreterType>();
        }

        public int ProtocolTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<EventInterpreterType> EventInterpreterTypes { get; set; }
    }
}
