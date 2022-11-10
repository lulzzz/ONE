using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PttappChatRoomSystemUser
    {
        public Guid PttappChatRoomSystemUserGuid { get; set; }
        public Guid? PttappChatRoomGuid { get; set; }
        public Guid? SystemUserGuid { get; set; }

        public virtual PttappChatRoom PttappChatRoomGu { get; set; }
        public virtual SystemUser SystemUserGu { get; set; }
    }
}
