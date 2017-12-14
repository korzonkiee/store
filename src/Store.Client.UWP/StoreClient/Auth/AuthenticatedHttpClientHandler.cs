using StoreClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StoreClient.Auth
{
    class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly LocalStorage localStorage;

        public AuthenticatedHttpClientHandler()
        {
            this.localStorage = new LocalStorage();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var accessToken = localStorage.GetAccessToken();
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, accessToken);
            }

            var result = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("User is unauthorized.");
                Console.WriteLine("Refreshing Access Token...");
                // refresh access_token
                // resend
            }

            return result;
        }
    }
}
