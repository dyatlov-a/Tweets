using System;

namespace Tweets.Queries.Dtos
{
    public class TweetsCollectionItemDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}
