using System;
using InventoryManagementSystemAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item { Id = Guid.NewGuid(), Name = "Item 1", Barcode = "0", DateAdded = DateTime.Now, UserId = 0},
                new Item { Id = Guid.NewGuid(), Name = "Item 2", Barcode = "1", DateAdded = DateTime.Now, UserId = 1},
                new Item { Id = Guid.NewGuid(), Name = "Item 3", Barcode = "2", DateAdded = DateTime.Now, UserId = 2}
            );
        }
    }
}