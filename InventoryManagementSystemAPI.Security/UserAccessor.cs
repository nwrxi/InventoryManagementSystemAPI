using System.Linq;
using System.Security.Claims;
using InventoryManagementSystemAPI.Data.SecurityInterfaces;
using Microsoft.AspNetCore.Http;

namespace InventoryManagementSystemAPI.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            //If user object exists in httpcontext we will get name identifier value
            var id =
                _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return id;
        }
    }
}