using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SqlAccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, ITokenGenerator tokenGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
        }
        public async Task<PublicUserViewModel> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded)
            {
                var userViewModel = _mapper.Map<PublicUserViewModel>(user);
                userViewModel.Token = _tokenGenerator.GenerateToken(user);
                return userViewModel;
            }

            return null;
        }
    }
}