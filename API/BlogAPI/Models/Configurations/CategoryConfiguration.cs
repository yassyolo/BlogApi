using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.BlogPosts)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new Category[] {data.Category1, data.Category2, data.Category3, data.Category4, data.Category5, data.Category6, data.Category7, data.Category8, data.Category9, data.Category10, data.Category11, data.Category12, data.Category13, data.Category14, data.Category15});
        }
    }
}
