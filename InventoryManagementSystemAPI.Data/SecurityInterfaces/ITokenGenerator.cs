using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.Data.SecurityInterfaces
{
    public interface ITokenGenerator
    {
        public string GenerateToken(User user);
    }
}