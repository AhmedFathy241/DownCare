using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class TakeScoreDTO
    {
        [Required]
        [RegularExpression(@"^(?i)(Linguistics|Communication)$",
            ErrorMessage = "The Type must be either 'Linguistics', or 'Communication'")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^(?i)(OneWord|TwoWord|ThreeWord|FourWord|FiveWord)$",
            ErrorMessage = "The Level must be either 'OneWord', 'TwoWord', 'ThreeWord', 'FourWord', or 'FiveWord'")]
        public string Level { get; set; }

        [Required]
        [RegularExpression(@"^(100|[1-9]0|0)$",
            ErrorMessage = "Score must be a multiple of 10 between 0-100")]
        public int Score { get; set; }
    }
}
