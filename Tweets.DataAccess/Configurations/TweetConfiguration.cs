using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweets.Domain.DataContracts;
using Tweets.Domain.Models.Tweets;

namespace Tweets.DataAccess.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        internal const string TableName = "eTweets";

        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.TweetsCollection)
                .WithMany(PropertyConsts.TweetsCollectionTweetsCollectionName)
                .HasForeignKey(t => t.TweetsCollectionId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Ignore(tc => tc.Pictures);
        }
    }
}
