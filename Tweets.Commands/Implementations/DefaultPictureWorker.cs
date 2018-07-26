using System;
using System.Linq;
using Tweets.Commands.Contracts;
using Tweets.Domain.Models.Tweets;
using Tweets.TwitterClient.Dtos;

namespace Tweets.Commands.Implementations
{
    public class DefaultPictureWorker : IPictureWorker
    {
        private const string DefaultMediaType = "photo";
        private const string DefaultTargetSize = "medium";

        private readonly string _mediaType;
        private readonly string _targetSize;

        public DefaultPictureWorker()
            : this(DefaultMediaType, DefaultTargetSize)
        {
        }

        public DefaultPictureWorker(string mediaType, string targetSize)
        {
            if (String.IsNullOrWhiteSpace(mediaType))
                throw new ArgumentNullException(nameof(mediaType));
            if (String.IsNullOrWhiteSpace(targetSize))
                throw new ArgumentNullException(nameof(targetSize));

            _mediaType = mediaType;
            _targetSize = targetSize;
        }

        public virtual void Do(Tweet targetTweet, TwitterEntitysDto pictureContainer)
        {
            if (targetTweet == null)
                throw new ArgumentNullException(nameof(targetTweet));
            if (pictureContainer == null)
                return;

            foreach (var picture in pictureContainer.Media.Where(m => m.Type == _mediaType))
            {
                var targetSize = picture.Sizes.Single(s => s.Key == _targetSize);
                targetTweet.AddPicture(new Picture(picture.Media_Url, targetSize.Value.W, targetSize.Value.H));
            }
        }
    }
}
