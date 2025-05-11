using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Name { get; set; }
        public bool IsGroup { get; set; } = false;

        // relation with message 1:m
        public virtual ICollection<Message>? Messages { get; set; }

        // relation with AppUser m:m
        public virtual ICollection<UserChatRoom> UserChatRooms { get; set; }

    }
}
