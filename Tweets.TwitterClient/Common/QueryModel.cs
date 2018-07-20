using System;
namespace Tweets.TwitterClient.Common
{
    public class QueryModel
    {
        public string Tag { get; private set; }
        public int Count { get; private set; }
        public string ResultType { get; private set; }

        public QueryModel(string tag, int count, string resultType)
        {
            if (String.IsNullOrWhiteSpace(tag))
                throw new ArgumentException(nameof(tag));
            if (String.IsNullOrWhiteSpace(resultType))
                throw new ArgumentException(nameof(resultType));

            Tag = tag;
            Count = count;
            ResultType = resultType;
        }
    }
}
