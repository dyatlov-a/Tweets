using System;
using System.Collections.Generic;

namespace Tweets.Queries.Dtos
{
    public class TweetDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public IEnumerable<PictureDto> Pictures { get; set; }
    }
}
