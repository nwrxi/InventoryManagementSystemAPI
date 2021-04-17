using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

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

            var user = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                IsAdmin = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "Pa$$w0rd");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User>(_context);
                await userStore.CreateAsync(user);
               
                var userManager = _context.GetService<UserManager<User>>();
                await userManager.AddToRolesAsync(user, new List<string> { "Admin" });
            }

            await _context.SaveChangesAsync();
        }
    }
}