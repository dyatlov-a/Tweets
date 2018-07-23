using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweets.Domain.Models.Tweets;

namespace Tweets.DataAccess.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        private const string TableName = "ePictures";

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Tweet)
                .WithMany("_pictures")
                .HasForeignKey(t => t.TweetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
