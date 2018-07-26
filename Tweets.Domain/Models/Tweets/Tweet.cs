using System;
using System.Collections.Generic;
using Tweets.Domain.Models.Base;

namespace Tweets.Domain.Models.Tweets
{
    public class Tweet : Entity
    {
        internal const string PicturesCollectionName = nameof(_pictures);

        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TweetsCollection TweetsCollection { get; private set; }
        public Guid TweetsCollectionId { get; private set; }

        private readonly ICollection<Picture> _pictures;

        public IEnumerable<Picture> Pictures => _pictures;

        private Tweet()
        {
            _pictures = new HashSet<Picture>();
        }

        public Tweet(DateTime createdAt, string text) : this()
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
            CreatedAt = createdAt;
        }

        public void AddPicture(Picture picture)
        {
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            if (_pictures.Contains(picture))
                return;

            _pictures.Add(picture);
        }
    }
}
