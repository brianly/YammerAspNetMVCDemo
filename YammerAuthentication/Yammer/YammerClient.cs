using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using DotNetOpenAuth.AspNet.Clients;
using DotNetOpenAuth.Messaging;
using Newtonsoft.Json;
using YammerAuthentication.Yammer.Models.User;

namespace YammerAuthentication.Yammer
{
    /// <summary>
    /// An OAuth2 client for Yammer. Handles a lot of yucky stuff.
    /// </summary>
    public class YammerClient : OAuth2Client
    {
        #region Constants and Fields

        /// <summary>
        /// The authorization endpoint.
        /// </summary>
        private const string AuthorizationEndpoint = "https://www.yammer.com/dialog/oauth";

        /// <summary>
        /// The token endpoint.
        /// </summary>
        private const string TokenEndpoint = "https://www.yammer.com/oauth2/access_token.json";

        /// <summary>
        /// The user endpoint.
        /// </summary>
        private const string CurrentUserEndpoint = "https://www.yammer.com/api/v1/users/current.json";

        /// <summary>
        /// The _app id.
        /// </summary>
        private readonly string _appId;

        /// <summary>
        /// The _app secret.
        /// </summary>
        private readonly string _appSecret;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YammerClient"/> class.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="appSecret">
        /// The app secret.
        /// </param>
        public YammerClient(string appId, string appSecret)
            : this("yammer", appId, appSecret)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YammerClient"/> class.
        /// </summary>
        /// <param name="providerName">The provider name.</param>
        /// <param name="appId">The app id.</param>
        /// <param name="appSecret">The app secret.</param>
        protected YammerClient(string providerName, string appId, string appSecret)
            : base(providerName)
        {
            //Requires.NotNullOrEmpty(appId, "appId");
            //Requires.NotNullOrEmpty(appSecret, "appSecret");

            _appId = appId;
            _appSecret = appSecret;
        }

        #endregion

        /// <summary>
        /// Gets the identifier for this client registered with Yammer.
        /// </summary>
        protected string AppId
        {
            get { return _appId; }
        }

        #region Methods

        /// <summary>
        /// Gets the full URL pointing to the login page for this client.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// An absolute URL.
        /// </returns>
        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {
            var b = new UriBuilder(AuthorizationEndpoint);
            b.AppendQueryArgument("client_id", _appId);
            b.AppendQueryArgument("redirect_uri", returnUrl.AbsoluteUri);

            return b.Uri;
        }



        /// <summary>
        /// Queries the access token from the specified authorization code to complete the OAuth2 dance.
        /// </summary>
        /// <param name="returnUrl">
        /// The return URL. 
        /// </param>
        /// <param name="authorizationCode">
        /// The authorization code. 
        /// </param>
        /// <returns>
        /// The query access token.
        /// </returns>
        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            var b = new UriBuilder(TokenEndpoint);
            b.AppendQueryArgument("client_id", _appId);
            b.AppendQueryArgument("client_secret", _appSecret);
            b.AppendQueryArgument("code", authorizationCode);

            var tokenRequest = WebRequest.Create(b.ToString());
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            if (tokenResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var responseStream = tokenResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var reader = new StreamReader(responseStream);
                        var responseJson = reader.ReadToEnd();
                        var deserializedProduct = JsonConvert.DeserializeObject<YammerToken>(responseJson);

                        Debug.WriteLine("QueryAccessToken() returned {0}", deserializedProduct.access_token.token);

                        return deserializedProduct.access_token.token;
                    }
                }
            }

            Debug.WriteLine("QueryAccessToken() returned null");
            return null;
        }

        /// <summary>
        /// Given the access token, gets the logged-in user's data. The returned dictionary must include two keys 'id', and 'username'.
        /// </summary>
        /// <param name="accessToken">
        /// The access token of the current user. 
        /// </param>
        /// <returns>
        /// A dictionary contains key-value pairs of user data 
        /// </returns>
        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            var b = new UriBuilder(CurrentUserEndpoint);
            b.AppendQueryArgument("access_token", accessToken);

            var tokenRequest = WebRequest.Create(b.ToString());
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            if (tokenResponse.StatusCode == HttpStatusCode.OK)
            {
                using (Stream responseStream = tokenResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var reader = new StreamReader(responseStream);
                        var responseJson = reader.ReadToEnd();
                        var user = JsonConvert.DeserializeObject<YammerUser>(responseJson);

                        var data = new Dictionary<string, string>();

                        data.Add("id", user.id.ToString());
                        data.Add("name", user.full_name);
                        data.Add("email", user.contact.email_addresses[0].address);
                        data.Add("jobTitle", user.job_title);
                        data.Add("location", user.location);
                        data.Add("mugshot", user.mugshot_url);
                        data.Add("network", user.network_name);
                        data.Add("profile", user.web_url);

                        Debug.WriteLine("QueryAccessToken() returned {0} items", data.Count);

                        return data;
                    }
                }
            }
            Debug.WriteLine("GetUserData() returned null");
            return null;
        }

        #endregion
    }
}