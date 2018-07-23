using System;
using System.Collections.Generic;

namespace Tweets.TwitterClient.Common
{
    public class TweetDto
    {
        public string Text { get; set; }
        public DateTime Created_At { get; set; }
        public EntitysDto Extended_Entities { get; set; }
    }
}
