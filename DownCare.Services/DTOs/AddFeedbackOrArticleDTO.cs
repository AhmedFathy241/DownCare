using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class AddFeedbackOrArticleDTO
    {
        [StringLength(200)]
        public string Content { get; set; }
    }
}
