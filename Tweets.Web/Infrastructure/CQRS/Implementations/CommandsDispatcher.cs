using System;
using System.Threading.Tasks;
using Tweets.Commands.Contracts;
using Tweets.Web.Infrastructure.CQRS.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Tweets.Web.Infrastructure.CQRS.Implementations
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandsDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext
        {
            return _serviceProvider.GetService<IAsyncCommand<TCommandContext>>().Execute(commandContext);
        }
    }
}
