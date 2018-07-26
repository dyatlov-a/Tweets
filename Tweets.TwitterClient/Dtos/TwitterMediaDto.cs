using System.Collections.Generic;

namespace Tweets.TwitterClient.Dtos
{
    public class TwitterMediaDto
    {
        public string Type { get; set; }
        public string Media_Url { get; set; }
        public IDictionary<string, TwitterSizeDto> Sizes { get; set; }
    }
}
