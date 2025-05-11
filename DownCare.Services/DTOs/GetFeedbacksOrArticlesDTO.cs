namespace DownCare.Services.DTOs
{
    public class GetFeedbacksOrArticlesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
    }
}
