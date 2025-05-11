using Microsoft.AspNetCore.Identity;

namespace DownCare.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string? PasswordResetCode { get; set; }
        public string Role { get; set; }
        public string Governate { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public string? ConnectionID { get; set; }
        public DateTime? JoinedAt { get; set; }
        public virtual ICollection<UserChatRoom> UserChatRooms { get; set; }

    }
}
