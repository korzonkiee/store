using Microsoft.AspNetCore.Identity;

namespace Store.Auth.Facebook
{
    public class FacebookRegisterUserResult
    {
        public bool IsSuccess { get; set; }
        public IdentityUser User { get; set; }
        public string ErrorString { get; set; }
    }
}