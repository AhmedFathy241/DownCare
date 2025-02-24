using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(50)]
        //[MinLength(3, ErrorMessage = "User Name must be at least 3 characters long.")]
        //[MaxLength(50, ErrorMessage = "User Name must be no more than 50 characters long.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm Password do not match.")]

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Governate { get; set; }

        [Required]
        [RegularExpression(@"^(?i)(Doctor|Mom)$",
            ErrorMessage = "The Role must be either 'Doctor', or 'Mom'")]
        public string Role { get; set; }
    }
}
