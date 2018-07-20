using System.Collections.Generic;

namespace Tweets.Queries.Dtos
{
    public class TweetsCollectionDto
    {
        public string Tag { get; set; }

        public IEnumerable<TweetsCollectionItemDto> Tweets { get; set; } = new List<TweetsCollectionItemDto>(0);
    }
}
