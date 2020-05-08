using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Application.ApiModels;
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
        // GET: 
        // api/Account/Login

        /// <summary>
        /// Generates bearer token for valid user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            return Ok();
        }
    }
}
