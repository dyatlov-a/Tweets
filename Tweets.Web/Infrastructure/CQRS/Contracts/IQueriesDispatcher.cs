using Tweets.Queries.Contracts;

namespace Tweets.Web.Infrastructure.CQRS.Contracts
{
    public interface IQueriesDispatcher
    {
        TResult Execute<TCriterion, TResult>(TCriterion criterion) where TCriterion : ICriterion<TResult>;
    }
}
