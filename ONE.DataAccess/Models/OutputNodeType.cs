using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class OutputNodeType
    {
        public OutputNodeType()
        {
            OutputNodes = new HashSet<OutputNode>();
        }

        public int OutputNodeTypeCode { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }
        public int ProtocolTypecode { get; set; }

        public virtual ICollection<OutputNode> OutputNodes { get; set; }
    }
}
