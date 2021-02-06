using System.Net;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.SecurityInterfaces;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystemAPI.Data.Repositories.AccountManagement
{
    public class SqlAccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;

        public SqlAccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<User> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded)
            {
                //TODO: generate token
                return new User
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    Image = null
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}