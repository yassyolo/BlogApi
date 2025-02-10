using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class ForumCommunityConfiguration : IEntityTypeConfiguration<ForumCommunity>
    {
        public void Configure(EntityTypeBuilder<ForumCommunity> builder)
        {
            builder.HasMany(x => x.ForumPosts)
                .WithOne(x => x.ForumCommunity)
                .HasForeignKey(x => x.ForumCommunityId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserForumCommunities)
                .WithOne(x => x.ForumCommunity)
                .HasForeignKey(x => x.ForumCommunityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Image)
                .WithOne(x => x.ForumCommunity)
                .HasForeignKey<Images>(x => x.ForumCommunityId)
                .OnDelete(DeleteBehavior.Restrict);
            var data = new SeedData();
            builder.HasData(new ForumCommunity[] { data.ForumCommunity1, data.ForumCommunity2, data.ForumCommunity3, data.ForumCommunity4, data.ForumCommunity5, data.ForumCommunity6, data.ForumCommunity7, });
        }
    }
}
