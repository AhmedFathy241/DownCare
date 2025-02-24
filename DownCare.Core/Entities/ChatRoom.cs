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

        // relation with message 1:m
        public virtual ICollection<Message>? Messages { get; set; }

        // relation with doctor 1:m
        [ForeignKey("Doctor")]
        public string DocID { get; set; }
        public virtual Doctor? Doctor { get; set; }

        // relation with mom m:m
        public virtual ICollection<Mom>? Moms { get; set; }
        
    }
}
