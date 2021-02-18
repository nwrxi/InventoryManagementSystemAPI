using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;

namespace InventoryManagementSystemAPI.Data.Repositories
{
    public interface IItemsRepository
    {
        Task<List<ItemDto>> GetItems();
        Task<ItemDto> GetItem(Guid id);
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task<Item> DeleteItem(Guid id);
        bool ItemExists(Guid id);
        bool BarcodeExists(string barcode);
    }
}