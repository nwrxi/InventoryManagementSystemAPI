using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.Data.SecurityInterfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}