using System;
using System.Collections.Generic;
using Tweets.Domain.Models.Base;

namespace Tweets.Domain.Models.Tweets
{
    public class TweetsCollection : Entity
    {
        public string Tag { get; private set; }

        public DateTime Created { get; private set; }

        private readonly ICollection<Tweet> _tweets;

        public IEnumerable<Tweet> Tweets => _tweets;

        private TweetsCollection()
        {
            _tweets = new HashSet<Tweet>();
        }

        public TweetsCollection(string tag) : this()
        {
            if (String.IsNullOrWhiteSpace(tag))
                throw new ArgumentNullException(nameof(tag));

            Tag = tag;
            Created = DateTime.UtcNow;
        }

        public void AddTweet(Tweet tweet)
        {
            if (tweet == null)
                throw new ArgumentNullException(nameof(tweet));

            if (_tweets.Contains(tweet))
                return;

            _tweets.Add(tweet);
        }
    }
}
