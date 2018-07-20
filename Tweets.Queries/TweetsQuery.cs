using System;
using Tweets.Queries.Contracts;
using Tweets.Queries.Criterions;
using Tweets.Queries.Dtos;

namespace Tweets.Queries
{
    public class TweetsQuery : IQuery<TweetsQueryCriterion, TweetsCollectionDto>
    {
        private readonly ITweetsProvider _tweetsProvider;

        public TweetsQuery(ITweetsProvider tweetsProvider)
        {
            _tweetsProvider = tweetsProvider ?? throw new ArgumentNullException(nameof(tweetsProvider));
        }

        public TweetsCollectionDto Ask(TweetsQueryCriterion tweetsQueryCriterion)
        {
            if (tweetsQueryCriterion == null)
                throw new ArgumentNullException(nameof(tweetsQueryCriterion));

            return _tweetsProvider.GetLast(tweetsQueryCriterion.Count);
        }
    }
}
