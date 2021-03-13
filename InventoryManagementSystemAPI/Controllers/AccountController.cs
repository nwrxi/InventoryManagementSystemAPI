using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;
using InventoryManagementSystemAPI.Data.Repositories.AccountManagement;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<PublicUserViewModel>> Login(Login login)
        {
            var result = await _repository.Login(login);

            if (result == null)
                return Unauthorized();

            return result;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<PublicUserViewModel>> Register(Register userRegister)
        {
            if (await _repository.EmailExists(userRegister.Email))
                return BadRequest(new {Email = "Email already exists"});

            if (await _repository.UsernameExists(userRegister.UserName))
                return BadRequest(new { Username = "Username already exists"});

            return await _repository.Register(userRegister);
        }

        [HttpGet]
        public async Task<ActionResult<PublicUserViewModel>> GetCurrentUser()
        {
            return await _repository.GetCurrentUser();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetUserPublicInfo(string id)
        {
            return await _repository.GetPublicUserInformation(id);
        }
    }
}
