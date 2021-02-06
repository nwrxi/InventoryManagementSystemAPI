using System;
using InventoryManagementSystemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>().HasData(
                new Item { Id = Guid.NewGuid(), Name = "Item 1", Barcode = "3070006005009", DateAdded = DateTime.Now, UserId = 0},
                new Item { Id = Guid.NewGuid(), Name = "Item 2", Barcode = "0070006005002", DateAdded = DateTime.Now, UserId = 1},
                new Item { Id = Guid.NewGuid(), Name = "Item 3", Barcode = "8074001005038", DateAdded = DateTime.Now, UserId = 2}
            );
        }
    }
}