namespace Store.Auth.Facebook
{
    public static class FacebookConsts
    {
        public const string GrantType = "facebook";
        public const string GrantField = "assertion";

        public static class Errors
        {
            public const string NoAssertion = "facebook_no_assertion";
            public const string InvalidAssertion = "facebook_invalid_assertion";
            public const string CouldNotRegisterUser = "could_not_register_user";
        }
    }
}