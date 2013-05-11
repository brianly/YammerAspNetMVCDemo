using Microsoft.Web.WebPages.OAuth;
using YammerAuthentication.Yammer;

namespace YammerAuthentication
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();

            // Pull these from your config!
            //const string appId = "ZCN6LuLlFTQbUzyCPBSjfA";
            //const string appSecret = "cw92hmcgH9o6TeizQ4iDQONco6c8DRDGA0ZGvHaM";

            const string appId = "W1bn1q8ZmNg0LxOG5lGsZw";
            const string appSecret = "NtjsBy36LDfSDBWNyAgWI1fcAlJX8yGOvToWoC9zGkA";

            // Custom OAuth2Client implementation
            var y = new YammerClient(appId, appSecret);
            
            // It'd be nice to have this built-in ;)
            OAuthWebSecurity.RegisterClient(y, "Yammer", null);
        }
    }
}
