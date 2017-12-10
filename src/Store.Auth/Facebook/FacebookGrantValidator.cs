using System;
using System.Threading.Tasks;
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
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    FacebookConsts.Errors.UserNotRegistered);
                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(), GrantType);
        }
    }
}