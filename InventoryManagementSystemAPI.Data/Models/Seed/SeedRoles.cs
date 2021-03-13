using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data.Models.Seed
{
    public class SeedRoles
    {
        private readonly DataContext _context;

        public SeedRoles(DataContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            }

            await _context.SaveChangesAsync();
        }
    }
}