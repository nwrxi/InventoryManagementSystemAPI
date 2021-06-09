using System;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;

namespace InventoryManagementSystemAPI.Data.Repositories.AccountManagement
{
    public interface IAccountRepository
    {
        Task<PublicUserViewModel> Login(Login login);
        Task<PublicUserViewModel> Register(Register userRegister);
        Task<PublicUserViewModel> RegisterAdmin(Register userRegister);
        Task<bool> EmailExists(string email);
        Task<bool> UsernameExists(string username);
        Task<PublicUserViewModel> GetCurrentUser();
        Task<UserProfileDto> GetPublicUserInformation(string id);
    }
}