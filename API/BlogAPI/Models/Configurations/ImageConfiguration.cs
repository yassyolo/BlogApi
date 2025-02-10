using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasOne(b => b.Blog)
                .WithMany(b => b.Images)
                .HasForeignKey(b => b.BlogId)
                .OnDelete(DeleteBehavior.Restrict);
            
            var data = new SeedData();
            builder.HasData(new Images[] {data.AchievemntImage1, data.AchievemntImage2, data.AchievemntImage3, data.AchievemntImage4, data.AchievemntImage5, data.AchievemntImage6, data.AchievemntImage7, data.AchievemntImage8, data.AchievemntImage9, data.AchievemntImage10, data.AchievemntImage11, data.AchievemntImage12, data.BlogImage1, data.BlogImage2, data.BlogImage3, data.BlogImage4, data.BlogImage5, data.BlogImage6, data.BlogImage7});
        }
    }
}
