using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class ChildDTO
    {
        [Required]
        [StringLength(200)]
        public string ChildName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateOnly DiagnosisDate { get; set; }

        [Required]
        [RegularExpression(@"^(?i)(Male|Female)$",
            ErrorMessage = "The Gneder must be either 'Male', or 'Female'")]
        public string Gneder { get; set; }
    }
}
