using System;
using System.Threading.Tasks;
using Tweets.Commands.CommandContexts;
using Tweets.Commands.Contracts;
using Tweets.Domain.Models.Tweets;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Contracts;

namespace Tweets.Commands.CommandHandlers
{
    public class TweetsRefreshCommand : IAsyncCommand<TweetsRefreshCommandContext>
    {
        private readonly ITweetsCollectionRepository _tweetsCollectionRepository;
        private readonly ITwitterClient _twitterClient;
        private readonly IUnitOfWork _unitOfWork;

        public TweetsRefreshCommand(ITweetsCollectionRepository tweetsCollectionRepository,
            ITwitterClient twitterClient,
            IUnitOfWork unitOfWork)
        {
            _tweetsCollectionRepository = tweetsCollectionRepository ?? throw new ArgumentNullException(nameof(tweetsCollectionRepository));
            _twitterClient = twitterClient ?? throw new ArgumentNullException(nameof(twitterClient));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task Execute(TweetsRefreshCommandContext tweetsRefreshCommandContext)
        {
            if (tweetsRefreshCommandContext == null)
                throw new ArgumentNullException(nameof(tweetsRefreshCommandContext));

            return ExecuteAction(tweetsRefreshCommandContext);
        }

        private async Task ExecuteAction(TweetsRefreshCommandContext tweetsRefreshCommandContext)
        {
            var tweets = await _twitterClient.QueryAsync(new QueryModel(tweetsRefreshCommandContext.Tag, tweetsRefreshCommandContext.Count, tweetsRefreshCommandContext.ResultType));
            var tweetsCollection = new TweetsCollection(tweetsRefreshCommandContext.Tag);

            foreach (var tweet in tweets)
            {
                tweetsCollection.AddTweet(new Tweet(tweet.Created_At, tweet.Text));
            }

            if (!tweetsRefreshCommandContext.IsSaveHistory)
            {
                await _tweetsCollectionRepository.RemoveAll();
            }

            _tweetsCollectionRepository.Insert(tweetsCollection);
            await _unitOfWork.SaveAsync();
        }
    }
}
