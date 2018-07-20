using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Contracts;

namespace Tweets.TwitterClient.Implementations
{
    public class DefaultTokenProvider : ITokenProvider
    {
        private readonly TwitterClientSettings _twitterClientSettings;
        private readonly IRequestSender _requestSender;

        public DefaultTokenProvider(TwitterClientSettings twitterClientSettings, IRequestSender requestSender)
        {
            _twitterClientSettings = twitterClientSettings ?? throw new ArgumentNullException(nameof(twitterClientSettings));
            _requestSender = requestSender ?? throw new ArgumentNullException(nameof(requestSender));
        }

        protected virtual string BuildCredentials()
        {
            var credentials = String.Format("{0}:{1}",
               HttpUtility.UrlEncode(_twitterClientSettings.ConsumerKey),
               HttpUtility.UrlEncode(_twitterClientSettings.ConsumerSecret));
            var credentialsBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            return credentialsBase64;
        }

        public virtual async Task<string> GetToken()
        {
            var jobjectResponse = await _requestSender.SendAsync(_twitterClientSettings.TokenUrl,
                TwitterClientConsts.Methods.POST, 
                $"Basic {BuildCredentials()}", 
                "grant_type=client_credentials");
            var token = jobjectResponse[_twitterClientSettings.AccessTokenFieldName].ToString();
            return token;
        }
    }
}
