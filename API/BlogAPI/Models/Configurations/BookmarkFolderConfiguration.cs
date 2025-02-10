using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class BookmarkFolderConfiguration : IEntityTypeConfiguration<BookmarkFolder>
    {
        public void Configure(EntityTypeBuilder<BookmarkFolder> builder)
        {
            builder.HasMany(x => x.Bookmarks)
                .WithOne(x => x.Folder)
                .HasForeignKey(x => x.FolderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User)
                .WithMany(x => x.BookmarkFolders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
