using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;

namespace Store.Auth.Facebook
{
    public class FacebookGrantValidator : IExtensionGrantValidator
    {
        public string GrantType => FacebookConsts.GrantType;

        private readonly FacebookClient facebookClient;
        private readonly UserManager<IdentityUser> userManager;

        public FacebookGrantValidator(FacebookClient facebookClient, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.facebookClient = facebookClient;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var token = context.Request.Raw[FacebookConsts.GrantField];
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    FacebookConsts.Errors.NoAssertion);
                return;
            }

            FacebookUser facebookUser = null;
            try
            {
                facebookUser = await facebookClient.GetFacebookUser(token);
            }
            catch
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    FacebookConsts.Errors.InvalidAssertion);
                return;
            }

            var user = await userManager.FindByLoginAsync(GrantType, facebookUser.Id);
            if (user == null)
            {
                Console.WriteLine($"Could not find user with id: {facebookUser.Id}");
                var result = await RegisterUser(facebookUser);
                if (result.IsSuccess)
                {
                    Console.WriteLine($"Successfully created user with id: {result.User.Id}");
                    user = result.User;
                }
                else
                {
                    Console.WriteLine($"Could not create user. Error: {result.ErrorString}");
                    HandleFacebookRegistrationFailure(context, result.ErrorString);
                }
            }

            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), GrantType);
            }
        }

        private void HandleFacebookRegistrationFailure(ExtensionGrantValidationContext context, string errors)
        {
            context.Result = new GrantValidationResult(
                FacebookConsts.Errors.CouldNotRegisterUser,
                errors                                
            );
        }

        private async Task<FacebookRegisterUserResult> RegisterUser(FacebookUser facebookUser)
        {
            Console.WriteLine("Beggining registration process...");

            var user = new IdentityUser()
            {
                Email = facebookUser.Email,
                UserName = facebookUser.Email,
                Id = Guid.NewGuid().ToString()
            };

            Console.WriteLine($"Initialized IdentityUser with id: {user.Id}");

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddLoginAsync(user, new UserLoginInfo(
                    FacebookConsts.GrantType,
                    facebookUser.Id,
                    "Facebook"));

                return new FacebookRegisterUserResult()
                {
                    IsSuccess = true,
                    User = user
                };
            }
            else
            {
                return new FacebookRegisterUserResult()
                {
                    IsSuccess = false,
                    ErrorString = GetFacebookRegistrationErrorString(result.Errors)
                };
            }
        }

        private string GetFacebookRegistrationErrorString(IEnumerable<IdentityError> errors)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.Append($"{error.Description},");
            }
            return stringBuilder.ToString();
        }
    }
}