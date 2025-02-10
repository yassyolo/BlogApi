using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            var data = new SeedData();
            builder.HasData(new Achievement[] { data.Achievement1, data.Achievement2, data.Achievement3, data.Achievement4, data.Achievement5, data.Achievement6, data.Achievement7, data.Achievement8, data.Achievement9, data.Achievement10, data.Achievement11, data.Achievement12 });
        }
    }
}
