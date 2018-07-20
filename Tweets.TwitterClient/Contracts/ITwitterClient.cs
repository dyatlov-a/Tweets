using System.Collections.Generic;
using System.Threading.Tasks;
using Tweets.TwitterClient.Common;

namespace Tweets.TwitterClient.Contracts
{
    public interface ITwitterClient
    {
        Task<IEnumerable<TweetDto>> QueryAsync(QueryModel queryModel);
    }
}
