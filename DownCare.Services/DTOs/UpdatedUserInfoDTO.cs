using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class UpdatedUserInfoDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Governate { get; set; }

        [StringLength(100)]
        public string? Specialization { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}