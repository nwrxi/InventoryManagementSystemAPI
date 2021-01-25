using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.Data.Repositories
{
    public interface IItemsRepository
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItem(Guid id);
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Item item);
        bool ItemExists(Guid id);
        bool BarcodeExists(string barcode);
    }
}