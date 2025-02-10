using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder.HasKey(x => new { x.UserId, x.AchievementId });
            var data = new SeedData();
            builder.HasData(new UserAchievement[] { data.UserAchievement1, data.UserAchievement2, data.UserAchievement3, data.UserAchievement4, data.UserAchievement5, data.UserAchievement6, data.UserAchievement7, data.UserAchievement8, data.UserAchievement9, data.UserAchievement10, data.UserAchievement11, data.UserAchievement12 });
        }
    }
}
