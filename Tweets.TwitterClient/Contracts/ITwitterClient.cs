using System.Collections.Generic;
using System.Threading.Tasks;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Dtos;

namespace Tweets.TwitterClient.Contracts
{
    public interface ITwitterClient
    {
        Task<IEnumerable<TwitterTweetDto>> QueryAsync(QueryModel queryModel);
    }
}
