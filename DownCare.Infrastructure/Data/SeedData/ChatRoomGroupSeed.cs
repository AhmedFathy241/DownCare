using DownCare.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DownCare.Infrastructure.Data.Configurations
{
    public class ChatRoomGroupSeed : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.HasData(
                new ChatRoom
                {
                    Id = 1,
                    Name = "MomsGroupChat",
                    IsGroup = true,
                    //CreatedAt = DateTime.Now
                });
        }
    }
}
