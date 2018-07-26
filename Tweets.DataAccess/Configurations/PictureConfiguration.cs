using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweets.Domain.DataContracts;
using Tweets.Domain.Models.Tweets;

namespace Tweets.DataAccess.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        internal const string TableName = "ePictures";

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Tweet)
                .WithMany(PropertyConsts.TweetPicturesCollectionName)
                .HasForeignKey(t => t.TweetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
