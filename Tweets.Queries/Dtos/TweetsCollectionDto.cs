using System;
using System.Collections.Generic;

namespace Tweets.Queries.Dtos
{
    public class TweetsCollectionDto
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }

        public DateTime Created { get; set; }

        public IEnumerable<TweetDto> Tweets { get; set; }

        public static TweetsCollectionDto Empty()
        {
            return new TweetsCollectionDto
            {
                Tweets = new TweetDto[0]
            };
        }
    }
}
