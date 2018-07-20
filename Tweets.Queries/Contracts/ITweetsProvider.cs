using System.Threading.Tasks;
using Tweets.Queries.Dtos;

namespace Tweets.Queries.Contracts
{
    public interface ITweetsProvider
    {
        TweetsCollectionDto GetLast(int count);
    }
}
