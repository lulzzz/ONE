using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class BlocklyBlock
    {
        public Guid BlocklyBlockCode { get; set; }
        public string BlocklyBlockTypeAttribute { get; set; }
        public int BlocklyBlockTypeCode { get; set; }
        public int BlocklyBlockCategoryTypeCode { get; set; }
        public string InnerBlockXml { get; set; }

        public virtual BlocklyBlockCategoryType BlocklyBlockCategoryTypeCodeNavigation { get; set; }
        public virtual BlocklyBlockType BlocklyBlockTypeCodeNavigation { get; set; }
    }
}
