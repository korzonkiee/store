using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Facebook
{
    public sealed class FacebookLoginResult
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
    }
}
