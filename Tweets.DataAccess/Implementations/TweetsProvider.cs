using Microsoft.EntityFrameworkCore;
using System;
using Tweets.DataAccess.Contexts;
using Tweets.Queries.Contracts;
using System.Linq;
using Tweets.Queries.Dtos;

namespace Tweets.DataAccess.Implementations
{
    public class TweetsProvider : ITweetsProvider
    {
        private readonly ReadContext _tweetsContext;

        public TweetsProvider(ReadContext tweetsContext)
        {
            _tweetsContext = tweetsContext ?? throw new ArgumentNullException(nameof(tweetsContext));
        }

        public TweetsCollectionDto GetLast()
        {
            var tweetsCollection = _tweetsContext.Set<TweetsCollectionDto>()
                .AsNoTracking()
                .Include(tc => tc.Tweets)
                .ThenInclude(t => t.Pictures)
                .OrderByDescending(t => t.Created)
                .Take(1)
                .ToArray();

            if (tweetsCollection.Length < 1)
            {
                return TweetsCollectionDto.Empty();
            }

            return tweetsCollection[0];
        }
    }
}
