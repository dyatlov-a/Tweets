using System.Threading.Tasks;
using Tweets.Domain.Models.Tweets;

namespace Tweets.Commands.Contracts
{
    public interface ITweetsCollectionRepository
    {
        void Insert(TweetsCollection tweetsCollection);
        Task RemoveAll();
    }
}
