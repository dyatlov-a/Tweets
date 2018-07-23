namespace Tweets.Queries.Contracts
{
    public interface IProjectionService
    {
        TProjection Map<TValue, TProjection>(TValue value);
    }
}
