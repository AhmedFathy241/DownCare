using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class AddFeedbackOrArticleDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(200)]
        public string? Content { get; set; }
    }
}
