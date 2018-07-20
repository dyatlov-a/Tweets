using System;
using Tweets.Commands.Contracts;

namespace Tweets.Commands.CommandContexts
{
    public class TweetsRefreshCommandContext : ICommandContext
    {
        public string Tag { get; private set; }

        public int Count { get; private set; }

        public bool IsSaveHistory { get; private set; }

        public string ResultType { get; private set; }

        public TweetsRefreshCommandContext(string tag, int count, bool isSaveHistory, string resultType)
        {
            if (String.IsNullOrWhiteSpace(tag))
                throw new ArgumentException(nameof(tag));
            if (String.IsNullOrWhiteSpace(resultType))
                throw new ArgumentException(nameof(resultType));

            Tag = tag;
            Count = count;
            IsSaveHistory = isSaveHistory;
            ResultType = resultType;
        }
    }
}
