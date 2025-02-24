using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

namespace DownCare.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Role { get; set; }
        public string Governate { get; set; }
        public string? PasswordResetCode { get; set; }
        public string? Bio { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        public string? ImagePath { get; set; }
    }
}
