using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream = BlogAPI.Models.Domain.Stream;

namespace BlogAPI.Models.Configurations
{
    public class StreamConfiguration : IEntityTypeConfiguration<Stream>
    {
        public void Configure(EntityTypeBuilder<Stream> builder)
        {
            builder.HasOne(s => s.Category)
                .WithMany(c => c.StreamPosts)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Owner)
                .WithMany(u => u.Streams)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
