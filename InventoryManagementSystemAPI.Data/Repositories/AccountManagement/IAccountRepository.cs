using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.Data.Repositories.AccountManagement
{
    public interface IAccountRepository
    {
        Task<PublicUserViewModel> Login(Login login);
        Task<PublicUserViewModel> Register(Register userRegister);
        Task<bool> EmailExists(string email);
        Task<bool> UsernameExists(string username);
        Task<PublicUserViewModel> GetCurrentUser();
    }
}