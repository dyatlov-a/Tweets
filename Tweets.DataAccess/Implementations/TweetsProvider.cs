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

        public TweetsProvider(TweetsContext tweetsContext)
        {
            _tweetsContext = tweetsContext ?? throw new ArgumentNullException(nameof(tweetsContext));
        }

        public TweetsCollectionDto GetLast(int count)
        {
            var tweetsCollection = _tweetsContext.Set<TweetsCollection>()
                .Include("_tweets")
                .AsNoTracking()
                .OrderByDescending(t => t.Created)
                .Take(1)
                .ToArray();

            if (tweetsCollection.Length < 1)
            {
                return new TweetsCollectionDto();
            }

            var result = new TweetsCollectionDto
            {
                Tag = tweetsCollection[0].Tag,
                Tweets = tweetsCollection[0].Tweets
                    .OrderByDescending(t => t.CreatedAt)
                    .Take(count)
                    .Select(t => new TweetsCollectionItemDto
                    {
                        Id = t.Id,
                        CreatedAt = t.CreatedAt,
                        Text = t.Text
                    })
            };
            return result;
        }
    }
}
