using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweets.Domain.Models.Tweets;

namespace Tweets.DataAccess.Configurations
{
    public class TweetsCollectionConfiguration : IEntityTypeConfiguration<TweetsCollection>
    {
        private const string TableName = "eTweetsCollections";
        private const string RowVersionColumnName = "RowVersion";

        public void Configure(EntityTypeBuilder<TweetsCollection> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(tc => tc.Id);

            builder.Ignore(tc => tc.Tweets);
            builder.Property<byte[]>(RowVersionColumnName).IsRowVersion();
        }
    }
}
