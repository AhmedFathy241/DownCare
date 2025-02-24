using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class ResetPasswordDTO
    {
        [EmailAddress]
        public string email { get; set; }
        public string code { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
