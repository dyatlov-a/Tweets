using Microsoft.EntityFrameworkCore;
using Tweets.DataAccess.Configurations;

namespace Tweets.DataAccess.Contexts
{
    public class TweetsContext : DbContext
    {
        public TweetsContext(DbContextOptions<TweetsContext> options)
            : base(options)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TweetConfiguration());
            modelBuilder.ApplyConfiguration(new TweetsCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
        }
    }
}
