using DownCare.Core.Entities;
using DownCare.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            //builder.ApplyConfiguration(new RoleSeedConfigration());
        }
        DbSet<Article> Articles { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<Child> Children { get; set; }
        DbSet<Activity> Activitys { get; set; }
        DbSet<ChatRoom> ChatRooms { get; set; }
        DbSet<Message> Messages { get; set; }
    }
}
