using Microsoft.EntityFrameworkCore;
using System;
using Tweets.DataAccess.Contexts;
using Tweets.Domain.Models.Tweets;
using Tweets.Queries.Contracts;
using System.Linq;
using Tweets.Queries.Dtos;

namespace Tweets.DataAccess.Implementations
{
    public class TweetsProvider : ITweetsProvider
    {
        private readonly TweetsContext _tweetsContext;
        private readonly IProjectionService _projectionService;

        public TweetsProvider(TweetsContext tweetsContext,
            IProjectionService projectionService)
        {
            _tweetsContext = tweetsContext ?? throw new ArgumentNullException(nameof(tweetsContext));
            _projectionService = projectionService ?? throw new ArgumentNullException(nameof(projectionService));
        }

        public TweetsCollectionDto GetLast()
        {
            var tweetsCollection = _tweetsContext.Set<TweetsCollection>()
                .Include("_tweets")
                .Include("_tweets._pictures")
                .AsNoTracking()
                .OrderByDescending(t => t.Created)
                .Take(1)
                .ToArray();

            if (tweetsCollection.Length < 1)
            {
                return TweetsCollectionDto.Empty();
            }

            var result = _projectionService.Map<TweetsCollection, TweetsCollectionDto>(tweetsCollection[0]);
            return result;
        }
    }
}
