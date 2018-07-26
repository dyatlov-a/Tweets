using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tweets.DataAccess.Configurations;
using Tweets.Domain.Models.Tweets;
using Tweets.Queries.Dtos;

namespace Tweets.DataAccess.Contexts
{
    public class ReadContext : DbContext
    {
        #region DisableWrite
        private const string ErrorMessage = "For SaveChanges need use WriteContext";

        public override int SaveChanges()
        {
            throw new NotSupportedException(ErrorMessage);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotSupportedException(ErrorMessage);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException(ErrorMessage);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException(ErrorMessage);
        }
        #endregion

        public ReadContext(DbContextOptions<ReadContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TweetsCollectionDto>().ToTable(TweetsCollectionConfiguration.TableName);
            modelBuilder.Entity<TweetsCollectionDto>().HasKey(tc => tc.Id);
            modelBuilder.Entity<TweetsCollectionDto>().HasMany(t => t.Tweets).WithOne().HasForeignKey(nameof(Tweet.TweetsCollectionId));

            modelBuilder.Entity<TweetDto>().ToTable(TweetConfiguration.TableName);
            modelBuilder.Entity<TweetDto>().HasKey(tc => tc.Id);
            modelBuilder.Entity<TweetDto>().HasMany(t => t.Pictures).WithOne().HasForeignKey(nameof(Picture.TweetId));

            modelBuilder.Entity<PictureDto>().ToTable(PictureConfiguration.TableName);
            modelBuilder.Entity<PictureDto>().HasKey(tc => tc.Id);
        }
    }
}
