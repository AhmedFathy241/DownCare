
namespace DownCare.Core.Entities
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Model { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();
    }
}
