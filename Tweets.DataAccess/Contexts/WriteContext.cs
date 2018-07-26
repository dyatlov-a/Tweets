using Microsoft.EntityFrameworkCore;
using Tweets.DataAccess.Configurations;

namespace Tweets.DataAccess.Contexts
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions<WriteContext> options)
            : base(options)
        {
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
