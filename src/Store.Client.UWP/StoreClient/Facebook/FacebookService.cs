using StoreClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winsdkfb;

namespace StoreClient.Facebook
{
    public interface IFacebookService
    {
        Task<FacebookLoginResult> LoginAsync();
        Task LogoutAsync();
    }

    public sealed class FacebookService : IFacebookService
    {
        private readonly FBSession facebookSession;

        public FacebookService()
        {
            facebookSession = InitializeFacebookSession();
        }

        public async Task<FacebookLoginResult> LoginAsync()
        {
            var facebookPermissions = GetFacebookPermissions();
            var loginResult = await facebookSession.LoginAsync(facebookPermissions);

            if (!loginResult.Succeeded)
            {
                HandleFacebookLoginError(loginResult.ErrorInfo);
                return new FacebookLoginResult() { IsSuccess = false };
            }

            if (!facebookSession.LoggedIn || facebookSession.AccessTokenData == null)
            {
                Logger.Log("Could not login via Facebook");
                return new FacebookLoginResult() { IsSuccess = false };
            }

            return new FacebookLoginResult()
            {
                IsSuccess = true,
                AccessToken = facebookSession.AccessTokenData.AccessToken
            };
        }

        public async Task LogoutAsync()
        {
            if (facebookSession != null && facebookSession.LoggedIn)
                await facebookSession.LogoutAsync();
        }

        private void HandleFacebookLoginError(FBError errorInfo)
        {
            if (errorInfo != null)
            {
                Logger.Log($"Could not login via Facebook. Error code: {errorInfo.Code}. Message: {errorInfo.Message}");
            }
        }

        private FBSession InitializeFacebookSession()
        {
            var facebookSession = FBSession.ActiveSession;
            facebookSession.FBAppId = FacebookConfig.FacebookAppId;

            return facebookSession;
        }

        private FBPermissions GetFacebookPermissions()
        {
            List<String> permissionList = new List<String>();
            foreach (var permission in FacebookConfig.FacebookRequiredPermissions)
            {
                permissionList.Add(permission);
            }
            return new FBPermissions(permissionList);
        }
    }


}
