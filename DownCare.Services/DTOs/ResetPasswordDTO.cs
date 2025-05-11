using System.ComponentModel.DataAnnotations;

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
