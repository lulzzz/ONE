using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PttappChatMessage
    {
        public Guid PttappChatMessageGuid { get; set; }
        public Guid? PttappChatRoomGuid { get; set; }
        public Guid? SenderGuid { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ReadBy { get; set; }

        public virtual PttappChatRoom PttappChatRoomGu { get; set; }
        public virtual SystemUser SenderGu { get; set; }
    }
}
