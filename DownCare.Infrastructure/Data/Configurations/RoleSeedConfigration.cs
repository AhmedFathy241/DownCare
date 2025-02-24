using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DownCare.Infrastructure.Data.Configurations
{
    public class RoleSeedConfigration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole 
                {
                    Id = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
                    Name = "Mom",
                    NormalizedName = "MOM"
                }
            );
        }
    }
}
