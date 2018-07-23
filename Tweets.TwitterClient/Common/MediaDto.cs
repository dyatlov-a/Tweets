using System.Collections.Generic;

namespace Tweets.TwitterClient.Common
{
    public class MediaDto
    {
        public string Type { get; set; }
        public string Media_Url { get; set; }
        public IDictionary<string, SizeDto> Sizes { get; set; }
    }
}
