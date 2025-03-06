namespace DownCare.Services.DTOs
{
    public class DoctorsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Governate { get; set; }
        public string Bio { get; set; } = "";
        public string ImagePath { get; set; } = "";
    }
}