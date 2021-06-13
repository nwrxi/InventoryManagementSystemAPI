using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystemAPI.Security
{
    public class IsAdmin : IAuthorizationRequirement
    {
        
    }

    public class IsAdminHandler : AuthorizationHandler<IsAdmin>
    {
        private readonly UserManager<User> _userManager;
        public IsAdminHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, IsAdmin requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (userId == null) return Task.CompletedTask;

            var isUserAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isUserAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}