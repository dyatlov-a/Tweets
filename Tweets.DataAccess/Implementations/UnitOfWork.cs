using System;
using System.Threading.Tasks;
using Tweets.Commands.Contracts;
using Tweets.DataAccess.Contexts;

namespace Tweets.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteContext _tweetsContext;

        public UnitOfWork(WriteContext tweetsContext)
        {
            _tweetsContext = tweetsContext ?? throw new ArgumentNullException(nameof(tweetsContext));
        }

        public async Task<int> SaveAsync()
        {
            return await _tweetsContext.SaveChangesAsync();
        }
    }
}
