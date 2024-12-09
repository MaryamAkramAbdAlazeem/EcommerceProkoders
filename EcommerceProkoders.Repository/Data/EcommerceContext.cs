using EcommerceProkoders.Core.Entities;
using EcommerceProkoders.Repository.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace EcommerceProkoders.Repository.Data
{
    public class EcommerceContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);

            builder.Entity<Product>()
            .HasMany(e => e.OrderItems)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

            builder.Entity<Order>()
            .HasMany(e => e.OrderItems)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);
        }
    }
}
