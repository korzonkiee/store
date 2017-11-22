using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(
                username,
                password,
                isPersistent: false,
                lockoutOnFailure: false
            );
            
            if (result.Succeeded)
            {
                return Content("Logged in.");
            }

            return Content("Something went wrong.");

        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Content("Logged out.");
        }

        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await userManager.CreateAsync(new IdentityUser()
            {
                UserName = username
            },
            password);

            if (result.Succeeded)
                return Content("Registered");
            return Content("Error");
        }
    }
}