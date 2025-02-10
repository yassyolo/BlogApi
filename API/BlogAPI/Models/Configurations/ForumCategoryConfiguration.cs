using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class ForumCategoryConfiguration : IEntityTypeConfiguration<ForumCategory>
    {
        public void Configure(EntityTypeBuilder<ForumCategory> builder)
        {
            builder.HasMany(x => x.ForumCommunities)
                .WithOne(x => x.ForumCategory)
                .HasForeignKey(x => x.ForumCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new ForumCategory[] { data.ForumCategory1, data.ForumCategory2, data.ForumCategory3, data.ForumCategory4, data.ForumCategory5 });
        }
    }
}
