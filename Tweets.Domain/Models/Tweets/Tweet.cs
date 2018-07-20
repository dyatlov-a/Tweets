using System;
using Tweets.Domain.Models.Base;

namespace Tweets.Domain.Models.Tweets
{
    public class Tweet : Entity
    {
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TweetsCollection TweetsCollection { get; private set; }
        public Guid TweetsCollectionId { get; private set; }

        private Tweet()
        {
        }

        public Tweet(DateTime createdAt, string text) : this()
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
            CreatedAt = createdAt;
        }
    }
}
