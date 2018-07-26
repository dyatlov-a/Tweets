using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tweets.Commands.Contracts;
using Tweets.DataAccess.Contexts;
using Tweets.Domain.Models.Tweets;

namespace Tweets.DataAccess.Implementations
{
    public class TweetsCollectionRepository : ITweetsCollectionRepository
    {
        private readonly WriteContext _tweetsContext;

        public TweetsCollectionRepository(WriteContext tweetsContext)
        {
            _tweetsContext = tweetsContext ?? throw new ArgumentNullException(nameof(tweetsContext));
        }

        public void Insert(TweetsCollection tweetsCollection)
        {
            _tweetsContext.Set<TweetsCollection>().Add(tweetsCollection);
        }

        public async Task RemoveAll()
        {
            var tweetsCollections = await _tweetsContext.Set<TweetsCollection>().ToListAsync();
            foreach (var tweetsCollection in tweetsCollections)
            {
                _tweetsContext.Remove(tweetsCollection);
            }
        }
    }
}
