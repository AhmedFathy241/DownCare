using DownCare.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace DownCare.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //builder.ApplyConfiguration(new RoleSeed());
            //builder.ApplyConfiguration(new ActivityDataSeed());
            //builder.ApplyConfiguration(new ChatRoomGroupSeed());
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Mom> Moms { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Child> Children { get; set; }
        public DbSet<ActivityData> ActivitiyData { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<UserChatRoom> UserChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
