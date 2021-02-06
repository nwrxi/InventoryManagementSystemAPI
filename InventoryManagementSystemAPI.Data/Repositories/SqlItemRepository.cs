using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data.Repositories
{
    public class SqlItemRepository : IItemsRepository
    {
        private readonly DataContext _context;

        public SqlItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItem(Guid id)
        {
            var item = await _context.Items.FindAsync(id);

            return item;
        }

        public async Task AddItem(Item item)
        {
            if(item == null)
                throw new ArgumentNullException($"{nameof(item)} entity can't be null");

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException($"{nameof(item)} entity can't be null");
            
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException($"{nameof(item)} entity can't be null");
            
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public bool ItemExists(Guid id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        public bool BarcodeExists(string barcode)
        {
            return _context.Items.Any(e => e.Barcode == barcode);
        }
    }
}