using System.Threading.Tasks;

namespace Tweets.Commands.Contracts
{
    public interface IAsyncCommand<in TCommandContext> where TCommandContext : ICommandContext
    {
        Task Execute(TCommandContext commandContext);
    }
}
