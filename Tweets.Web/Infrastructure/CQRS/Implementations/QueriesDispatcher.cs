using System;
using Tweets.Queries.Contracts;
using Tweets.Web.Infrastructure.CQRS.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Tweets.Web.Infrastructure.CQRS.Implementations
{
    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueriesDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public TResult Execute<TCriterion, TResult>(TCriterion criterion) where TCriterion : ICriterion<TResult>
        {
            return _serviceProvider.GetService<IQuery<TCriterion, TResult>>().Ask(criterion);
        }
    }
}
