using System.Collections.Generic;

namespace Tweets.TwitterClient.Dtos
{
    public class TwitterEntitysDto
    {
        public IEnumerable<TwitterMediaDto> Media { get; set; }
    }
}
