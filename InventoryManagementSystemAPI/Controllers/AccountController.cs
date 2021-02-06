using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.Models;
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
    }
}
