using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.API.Filters;
using CMS.Application.ApiModels;
using CMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    /// <summary>
    /// Account REST API for generating token, refresh token
    /// </summary>
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: 
        // api/Account/Login

        /// <summary>
        /// Generates bearer token for valid user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateModel]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
           var loginDetails = _accountService.Authenticate(loginModel.UserName, loginModel.Password);
            return Ok(loginDetails);
        }
    }
}
