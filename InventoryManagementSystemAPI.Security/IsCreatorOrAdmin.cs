using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public IsCreatorOrAdminHandler(IHttpContextAccessor httpContextAccessor, DataContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsCreatorOrAdmin requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) return Task.CompletedTask;

            var isUserAdmin = context.User.IsInRole("Admin");

            if(isUserAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            };

            var itemId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
                .SingleOrDefault(x => x.Key == "id").Value?.ToString()!);

            var item = _dbContext.Items
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == itemId).Result;

            if(item == null) return Task.CompletedTask;

            if(item.UserId == userId)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}