using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class UserForumCommunityConfiguration : IEntityTypeConfiguration<UserForumCommuntity>
    {
        public void Configure(EntityTypeBuilder<UserForumCommuntity> builder)
        {
            builder.HasKey(ufc => new { ufc.UserId, ufc.ForumCommunityId });
        }
    }
}
