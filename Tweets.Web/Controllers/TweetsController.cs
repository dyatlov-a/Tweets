using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tweets.Commands.CommandContexts;
using Tweets.Queries.Criterions;
using Tweets.Queries.Dtos;
using Tweets.Web.Infrastructure;
using Tweets.Web.Infrastructure.CQRS.Contracts;
using Tweets.Web.Infrastructure.Filters;
using Tweets.Web.InputModels;

namespace Tweets.Web.Controllers
{
    public class TweetsController : ApiV1Controller
    {
        private readonly IQueriesDispatcher _queriesDispatcher;
        private readonly ICommandsDispatcher _commandsDispatcher;
        private readonly TweetsSettings _tweetsSettings;

        public TweetsController(IQueriesDispatcher queriesDispatcher, 
            ICommandsDispatcher commandsDispatcher,
            TweetsSettings tweetsSettings)
        {
            _queriesDispatcher = queriesDispatcher ?? throw new ArgumentNullException(nameof(queriesDispatcher));
            _commandsDispatcher = commandsDispatcher ?? throw new ArgumentNullException(nameof(commandsDispatcher));
            _tweetsSettings = tweetsSettings ?? throw new ArgumentNullException(nameof(tweetsSettings));
        }

        [HttpGet]
        public TweetsCollectionDto Get()
        {
            return _queriesDispatcher.Execute<TweetsQueryCriterion, TweetsCollectionDto>(new TweetsQueryCriterion());
        }

        [HttpPost, ModelStateValidationFilter]
        public async Task<IActionResult> Post([FromBody]TagInputModel tag)
        {
            await _commandsDispatcher.ExecuteAsync(new TweetsRefreshCommandContext(tag.Value, _tweetsSettings.TweetsCount, _tweetsSettings.IsSaveHistory, _tweetsSettings.ResultType));
            return Ok();
        }
    }
}
