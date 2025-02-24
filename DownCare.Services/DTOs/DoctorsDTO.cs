using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class DoctorsDTO
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

        [StringLength(200)]
        public string Bio { get; set; }
        public string ImagePath { get; set; }
    }
}
