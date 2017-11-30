using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Store.Auth.Facebook
{
    public class FacebookClient : IDisposable
    {
        private const string BaseUrl = "https://graph.facebook.com/v2.11/";
        private const short PhotoSize = 200;

        private readonly HttpClient httpClient;
        private readonly HMACSHA256 hmac;

        public FacebookClient(IConfiguration configuration)
        {
            this.httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            this.hmac = new HMACSHA256(GetKey(configuration["Secrets:Facebook"]));
        }

        private byte[] GetKey(string secret)
        {
            return Encoding.ASCII.GetBytes(secret);
        }

        public async Task<FacebookUser> GetFacebookUser(string accessToken)
        {
            var proof = GenerateProof(accessToken);
            var uri = $"me?fields={GetFields()}&access_token={accessToken}&appsecret_proof={proof}";

            try
            {
                using (var response = await httpClient.GetAsync(uri))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception($"Could not call Facebook Graph Api. Status code: {response.StatusCode}");

                    var content = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(content);

                    if (result["error"] != null)
                        throw new Exception($"Could not call Facebook Graph Api. Code: {result["error"]["code"].Value<int>()}, Message: {result["error"]["message"]}");

                    return CreateFacebookUser(result);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Problem while calling Facebook Graph Api", e);
            }
        }

        private FacebookUser CreateFacebookUser(JObject @object)
        {
            var id = @object["id"].Value<string>();
            var email = @object["email"]?.Value<string>();
            var firstName = @object["first_name"]?.Value<string>();
            var lastName = @object["last_name"]?.Value<string>();
            var photoUrl = @object["picture"]["data"]["url"]?.Value<string>();
            return new FacebookUser(id, email, firstName, lastName, photoUrl);
        }

        private string GenerateProof(string accessToken)
        {
            var bytes = Encoding.ASCII.GetBytes(accessToken);
            var hash = hmac.ComputeHash(bytes);
            return ToHexString(hash);
        }

        private static string ToHexString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty).ToLower();
        }

        private static string GetFields()
        {
            return $"id,email,first_name,last_name,picture.width({PhotoSize}).height({PhotoSize})";
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}