using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.Auth.ControllerParams;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Services;

namespace Store.Auth.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBus bus;
        public RegisterUserService(UserManager<IdentityUser> userManager, IBus bus)
        {
            this.bus = bus;
            this.userManager = userManager;

        }

        public async Task<bool> Register(string email, string password)
        {
            var user = new IdentityUser()
            {
                Email = email,
                UserName = email
            };

            var result = await userManager.CreateAsync(user, password);
            await userManager.AddClaimAsync(user, new Claim("role", "user"));

            return result.Succeeded;
        }

        public async Task RequestRegistration(string email, string password)
        {
            await bus.SendCommand(new RegisterUserCommand(email, password));
        }
    }
}