using Tweets.Queries.Contracts;
using Tweets.Queries.Dtos;

namespace Tweets.Queries.Criterions
{
    public class TweetsQueryCriterion : ICriterion<TweetsCollectionDto>
    {
        public int Count { get; private set; }

        public TweetsQueryCriterion(int count)
        {
            Count = count;
        }
    }
}
