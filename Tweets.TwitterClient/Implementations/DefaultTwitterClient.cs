using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Contracts;

namespace Tweets.TwitterClient.Implementations
{
    public class DefaultTwitterClient : ITwitterClient
    {
        private readonly TwitterClientSettings _twitterClientSettings;
        private readonly ITokenProvider _tokenProvider;
        private readonly IRequestSender _requestSender;

        public DefaultTwitterClient(TwitterClientSettings twitterClientSettings, 
            ITokenProvider tokenProvider,
            IRequestSender requestSender)
        {
            _twitterClientSettings = twitterClientSettings ?? throw new ArgumentNullException(nameof(twitterClientSettings));
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
            _requestSender = requestSender ?? throw new ArgumentNullException(nameof(requestSender));
        }

        private string BuildUrl(QueryModel queryModel)
        {
            return String.Format(_twitterClientSettings.QueryUrlPattern, HttpUtility.UrlEncode(queryModel.Tag), queryModel.Count, queryModel.ResultType);
        }

        private IsoDateTimeConverter GetIsoDateTimeConverter()
        {
            return new IsoDateTimeConverter
            {
                Culture = new CultureInfo(_twitterClientSettings.CultureInfo),
                DateTimeFormat = _twitterClientSettings.DateTimeFormat
            };
        }

        public Task<IEnumerable<TweetDto>> QueryAsync(QueryModel queryModel)
        {
            if (queryModel == null)
                throw new ArgumentNullException(nameof(queryModel));

            return QueryAsyncAction(queryModel);
        }

        private async Task<IEnumerable<TweetDto>> QueryAsyncAction(QueryModel queryModel)
        {
            var token = await _tokenProvider.GetToken();
            var json = await _requestSender.SendAsync(BuildUrl(queryModel), TwitterClientConsts.Methods.GET, $"Bearer {token}");
            var statuses = json[_twitterClientSettings.TweetsFieldName].ToString();
            var result = JsonConvert.DeserializeObject<IEnumerable<TweetDto>>(statuses, GetIsoDateTimeConverter());
            return result;
        }
    }
}
