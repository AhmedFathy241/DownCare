using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        // relation with chatRoom 1:m
        [ForeignKey("ChatRoom")]
        public int ChatRoomID { get; set; }
        public virtual ChatRoom? ChatRoom { get; set; }
    }
}
