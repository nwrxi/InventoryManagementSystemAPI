using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data;
using InventoryManagementSystemAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Security
{
    public class IsCreatorOrAdmin : IAuthorizationRequirement
    {
    }

    public class IsCreatorOrAdminHandler : AuthorizationHandler<IsCreatorOrAdmin>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dbContext;
        private readonly UserManager<User> _userManager;

        public IsCreatorOrAdminHandler(IHttpContextAccessor httpContextAccessor, DataContext dbContext, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, IsCreatorOrAdmin requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (userId == null) return Task.CompletedTask;

            var isUserAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if(isUserAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            };

            var itemId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
                .SingleOrDefault(x => x.Key == "id").Value?.ToString()!);

            var item = await _dbContext.Items
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == itemId);

            if(item == null) return Task.CompletedTask;

            if(item.UserId == userId)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}