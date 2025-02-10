using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class VisitedForumCommunityConfiguration : IEntityTypeConfiguration<VisitedForumCommunity>
    {
        public void Configure(EntityTypeBuilder<VisitedForumCommunity> builder)
        {
            builder.HasKey(vfc => new { vfc.UserId, vfc.ForumCommunityId });
            var data = new SeedData();
            builder.HasData(new VisitedForumCommunity[] { data.VisitedForumCommunity1, data.VisitedForumCommunity2, });
        }
    }
}
