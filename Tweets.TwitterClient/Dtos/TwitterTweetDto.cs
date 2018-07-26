using System;
using System.Collections.Generic;

namespace Tweets.TwitterClient.Dtos
{
    public class TwitterTweetDto
    {
        public string Text { get; set; }
        public DateTime Created_At { get; set; }
        public TwitterEntitysDto Extended_Entities { get; set; }
    }
}
