using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Bookmarks)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Bookmarks)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
