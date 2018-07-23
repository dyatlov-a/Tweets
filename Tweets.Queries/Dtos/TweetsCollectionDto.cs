using System.Collections.Generic;

namespace Tweets.Queries.Dtos
{
    public class TweetsCollectionDto
    {
        public string Tag { get; set; }

        public IEnumerable<TweetsCollectionItemDto> Tweets { get; set; }

        public static TweetsCollectionDto Empty()
        {
            return new TweetsCollectionDto
            {
                Tweets = new TweetsCollectionItemDto[0]
            };
        }
    }
}
