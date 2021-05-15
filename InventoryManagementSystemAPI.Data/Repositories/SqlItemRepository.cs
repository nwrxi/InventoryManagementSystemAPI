using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;
using InventoryManagementSystemAPI.Data.SecurityInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data.Repositories
{
    public class SqlItemRepository : IItemsRepository
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<User> _userManager;
        private DbSet<Item> _itemSet;
        private readonly IMapper _mapper;

        public SqlItemRepository(DataContext context, IUserAccessor userAccessor, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userAccessor = userAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<ItemDto>> GetItems()
        {
            //todo: fix for others + DTOs
            var items = await _context.Items.Include(i => i.User).ToListAsync();
            return items.Select(item => _mapper.Map<ItemDto>(item)).ToList();
        }

        public async Task<ItemDto> GetItem(Guid id)
        {
            var item = await _context.Items.Include(i => i.User).FirstOrDefaultAsync(i => id == i.Id);
            return _mapper.Map<ItemDto>(item);
        }

        public async Task AddItem(Item item)
        {
            if(item == null)
                throw new ArgumentNullException($"{nameof(item)} entity can't be null");

            var userId = _userAccessor.GetCurrentUserId();
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
                throw new ArgumentNullException($"{nameof(user)} entity can't be null");

            item.UserId = userId;
            item.User = user;

            await _context.Items.AddAsync(item);

            //TODO: check if needed
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Guid id, Item item)
        {
            if (item == null)
                throw new ArgumentNullException($"{nameof(item)} entity can't be null");

            //var userId = _userAccessor.GetCurrentUserId();
            //var user = await _userManager.FindByIdAsync(userId);

            //if (user == null)
            //    throw new ArgumentNullException($"{nameof(user)} entity can't be null");

            //_context.Update(item);

            var itemInDb = await _context.Items.Include(i => i.User).FirstOrDefaultAsync(i => id == i.Id);

            item.UserId = itemInDb.UserId;
            item.User = itemInDb.User;

            _context.Entry(itemInDb).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> DeleteItem(Guid id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return null;
            
            _context.Remove(item);
            await _context.SaveChangesAsync();

            return item;
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