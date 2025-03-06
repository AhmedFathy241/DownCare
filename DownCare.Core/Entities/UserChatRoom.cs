using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ChatRoomId))]
    public class UserChatRoom
    {
        public string UserId { get; set; }
        public int ChatRoomId { get; set; } 

        public AppUser? User { get; set; }
        public ChatRoom? ChatRoom { get; set; }
    }
}
