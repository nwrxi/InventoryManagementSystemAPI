﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.SecurityInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data.Repositories.AccountManagement
{
    public class JwtAccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public JwtAccountRepository
            (UserManager<User> userManager, SignInManager<User> signInManager, ITokenGenerator tokenGenerator, IMapper mapper, IUserAccessor userAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
            _userAccessor = userAccessor;
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

        public async Task<PublicUserViewModel> GetCurrentUser()
        {
            var user = await _userManager.FindByIdAsync(_userAccessor.GetCurrentUserId());
            
            var publicUser = _mapper.Map<PublicUserViewModel>(user);
            publicUser.Token = _tokenGenerator.GenerateToken(user);
            return publicUser;
        }

        public async Task<PublicUserViewModel> Register(Register registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                var returnUser = _mapper.Map<PublicUserViewModel>(user);
                returnUser.Token = _tokenGenerator.GenerateToken(user);
                return returnUser;
            }

            throw new Exception("Problem with creating user");
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username);
        }

       
    }
}