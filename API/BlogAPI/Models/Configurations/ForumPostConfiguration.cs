using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class ForumPostConfiguration : IEntityTypeConfiguration<ForumPost>
    {
        public void Configure(EntityTypeBuilder<ForumPost> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.ForumPosts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.ForumPost)
                .HasForeignKey(x => x.ForumPostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image)
                .WithOne(x => x.ForumPost)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new ForumPost[] { data.ForumPost1, data.ForumPost2, data.ForumPost3, data.ForumPost4, data.ForumPost5, data.ForumPost6, data.ForumPost7, data.ForumPost8 });

        }
    }
}
