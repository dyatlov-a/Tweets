using System.Threading.Tasks;
using Tweets.Commands.Contracts;

namespace Tweets.Web.Infrastructure.CQRS.Contracts
{
    public interface ICommandsDispatcher
    {
        Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
    }
}
