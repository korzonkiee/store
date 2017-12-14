using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services
{
    public class LocalStorage
    {
        public string GetAccessToken()
        {
            return (string) Windows.Storage.ApplicationData.Current.LocalSettings.Values["access_token"];
        }

        public void SetAccessToken(string accessToken, string refreshToken)
        {
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["access_token"] = accessToken;
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["refresh_token"] = accessToken;
        }
    }
}
