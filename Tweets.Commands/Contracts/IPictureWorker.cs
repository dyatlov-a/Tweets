using Tweets.Domain.Models.Tweets;
using Tweets.TwitterClient.Common;

namespace Tweets.Commands.Contracts
{
    public interface IPictureWorker
    {
        void Do(Tweet targetTweet, EntitysDto pictureContainer);
    }
}
