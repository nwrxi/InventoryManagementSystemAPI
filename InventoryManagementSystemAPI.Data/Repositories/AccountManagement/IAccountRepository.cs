using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.Data.Repositories.AccountManagement
{
    public interface IAccountRepository
    {
        Task<PublicUserViewModel> Login(Login login);
    }
}