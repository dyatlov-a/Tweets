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
        private readonly IPictureWorker _pictureWorker;

        public TweetsRefreshCommand(ITweetsCollectionRepository tweetsCollectionRepository,
            ITwitterClient twitterClient,
            IUnitOfWork unitOfWork,
            IPictureWorker pictureWorker)
        {
            _tweetsCollectionRepository = tweetsCollectionRepository ?? throw new ArgumentNullException(nameof(tweetsCollectionRepository));
            _twitterClient = twitterClient ?? throw new ArgumentNullException(nameof(twitterClient));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _pictureWorker = pictureWorker ?? throw new ArgumentNullException(nameof(pictureWorker));
        }

        public Task Execute(TweetsRefreshCommandContext tweetsRefreshCommandContext)
        {
            if (tweetsRefreshCommandContext == null)
                throw new ArgumentNullException(nameof(tweetsRefreshCommandContext));

            return ExecuteAction(tweetsRefreshCommandContext);
        }

        private async Task ExecuteAction(TweetsRefreshCommandContext tweetsRefreshCommandContext)
        {
            var sourceTweets = await _twitterClient.QueryAsync(new QueryModel(tweetsRefreshCommandContext.Tag, tweetsRefreshCommandContext.Count, tweetsRefreshCommandContext.ResultType));
            var tweetsCollection = new TweetsCollection(tweetsRefreshCommandContext.Tag);

            foreach (var sourceTweet in sourceTweets)
            {
                var targetTweet = new Tweet(sourceTweet.Created_At, sourceTweet.Text);
                _pictureWorker.Do(targetTweet, sourceTweet.Extended_Entities);
                tweetsCollection.AddTweet(targetTweet);
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
