using System;
using Tweets.Domain.Models.Base;

namespace Tweets.Domain.Models.Tweets
{
    public class Picture : Entity
    {
        public string Url { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }

        public Tweet Tweet { get; private set; }
        public Guid TweetId { get; private set; }

        private Picture()
        {
        }

        public Picture(string url, int weight, int height) 
            : this()
        {
            if (String.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            Url = url;
            Weight = weight;
            Height = height;
        }
    }
}
