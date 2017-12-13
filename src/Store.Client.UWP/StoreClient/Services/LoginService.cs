﻿using StoreClient.Facebook;
using StoreClient.Utils;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services
{
    public sealed class LoginService : AuthService
    {
        private readonly IFacebookService facebookService;

        public LoginService()
        {
            facebookService = new FacebookService();
        }

        public async Task<LoginResult> LoginWithFacebook()
        {
            var result = await facebookService.LoginAsync();
            if (result.IsSuccess)
            {
                var response = await TokenClient.RequestAssertionAsync(FacebookConfig.FacebookAssertion, result.AccessToken, "email");
                if (!response.IsError)
                {
                    return new LoginResult()
                    {
                        IsSuccess = true,
                        Token = new Tuple<string, string>(response.AccessToken, response.RefreshToken)                        
                    };
                }
                
                Logger.Log($"Could not login. StatusCode: {response.HttpStatusCode}, Error: {response.HttpErrorReason}");
                return new LoginResult() { IsSuccess = false };
            }
            else
            {
                return new LoginResult() { IsSuccess = false };
            }
        }

        public async Task Logout()
        {
            await facebookService.LogoutAsync();
        }
    }

    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public Tuple<string, string> Token { get; set; }
    }
}
