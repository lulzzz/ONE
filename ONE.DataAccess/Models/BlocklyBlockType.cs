using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BlocklyBlockType
    {
        public BlocklyBlockType()
        {
            BlocklyBlocks = new HashSet<BlocklyBlock>();
        }

        public int BlocklyBlockTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<BlocklyBlock> BlocklyBlocks { get; set; }
    }
}
