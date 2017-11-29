using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store.Auth.Controllers
{
    [Route("auth/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        
        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
        }
    }
}
