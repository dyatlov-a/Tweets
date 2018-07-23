using AutoMapper;
using System;
using Tweets.Queries.Contracts;
using Tweets.Web.Infrastructure.Profiles;

namespace Tweets.Web.Infrastructure
{
    public class ProjectionService : IProjectionService
    {
        static ProjectionService()
        {
            Mapper.Initialize(c => c.AddProfile<TweetsProfile>());
        }

        public TProjection Map<TValue, TProjection>(TValue value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var result = Mapper.Map<TValue, TProjection>(value);
            return result;
        }
    }
}
