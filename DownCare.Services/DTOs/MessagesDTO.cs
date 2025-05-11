namespace DownCare.Services.DTOs
{
    public class MessagesDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string DisplayTime { get; set; }
        public string UserName { get; set; }
        public string UserImageURL { get; set; }
    }
}