using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Auth.ControllerParams;
using Store.Domain.Events;
using Store.Domain.Services;

namespace Store.Auth.Controllers
{
    [AllowAnonymous]
    [Route("auth/account")]
    public class AccountController : BaseAuthController
    {
        private readonly IRegisterUserService registerUserService;
        public AccountController(IRegisterUserService registerUserService,
            INotificationHandler<DomainEvent> events) : base(events)
        {
            this.registerUserService = registerUserService;
        }

        

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserParams @params)
        {
            await registerUserService.RequestRegistration(@params.Email, @params.Password);
            return ActionResponse(@params.Email);
        }
    }
}
