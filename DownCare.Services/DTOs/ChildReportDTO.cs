
namespace DownCare.Services.DTOs
{
    public class ChildReportDTO
    {
        public string? ChildName { get; set; }
        public int Age { get; set; }
        public DateOnly DiagnosisDate { get; set; }
        public string? Gneder { get; set; }
        public ScoreDTO? LinguisticsScore { get; set; }
        public ScoreDTO? CommunicationScore { get; set; } 
    }
}
