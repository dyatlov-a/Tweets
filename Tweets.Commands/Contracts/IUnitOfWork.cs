using System.Threading.Tasks;

namespace Tweets.Commands.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}
