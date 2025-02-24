using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Doctor : AppUser
    {
        // relation with mom m:m
        public virtual ICollection<Mom>? Moms { get; set; }

        // relation with article 1:m
        public virtual ICollection<Article>? Articles { get; set; }

        // relation with chatRoom 1:m
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
