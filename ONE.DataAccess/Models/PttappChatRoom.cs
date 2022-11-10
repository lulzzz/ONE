using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PttappChatRoom
    {
        public PttappChatRoom()
        {
            PttappChatMessages = new HashSet<PttappChatMessage>();
            PttappChatRoomSystemUsers = new HashSet<PttappChatRoomSystemUser>();
        }

        public Guid PttappChatRoomGuid { get; set; }
        public string PttappChatRoomName { get; set; }

        public virtual ICollection<PttappChatMessage> PttappChatMessages { get; set; }
        public virtual ICollection<PttappChatRoomSystemUser> PttappChatRoomSystemUsers { get; set; }
    }
}
