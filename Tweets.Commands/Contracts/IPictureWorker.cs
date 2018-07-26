using Tweets.Domain.Models.Tweets;
using Tweets.TwitterClient.Dtos;

namespace Tweets.Commands.Contracts
{
    public interface IPictureWorker
    {
        void Do(Tweet targetTweet, TwitterEntitysDto pictureContainer);
    }
}
