using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.Repository.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "6ea6fa14 - 2354 - 4db3 - 8bca - 9ba1c03229ff",
                    Name = "Admin",
                    NormalizedName = "Admin"
                },

                new IdentityRole
                {
                    Id= "e56ea50d-9354-44c9-9d63-8633aa491134",
                    Name = "User",
                    NormalizedName = "User"
                }



            );
        }
    } }
