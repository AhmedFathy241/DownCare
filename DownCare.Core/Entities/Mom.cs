using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Mom : AppUser
    {
        // relation with doctor m:m
        public virtual ICollection<Doctor>? Doctors { get; set; }

        // relation with child 1:1
        public virtual Child? Child { get; set; }

        // relation with report 1:1
        public virtual Report? Report { get; set; }

        // relation with feedback 1:m
        public virtual ICollection<Feedback>? Feedbacks { get; set; }

        // relation with chatRoom m:m
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
