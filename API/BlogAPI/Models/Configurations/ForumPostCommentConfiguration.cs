using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class ForumPostCommentConfiguration : IEntityTypeConfiguration<ForumPostComment>
    {
        public void Configure(EntityTypeBuilder<ForumPostComment> builder)
        {
            builder.HasOne( x=> x.User)
                .WithMany(x => x.ForumPostComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
