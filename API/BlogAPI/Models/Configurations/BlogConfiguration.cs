using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog> 
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasMany(x => x.Comments)
            .WithOne(x => x.BlogPost)
            .HasForeignKey(x => x.BlogPostId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new Blog[] {data.Blog1, data.Blog2, data.Blog3, data.Blog4, data.Blog5, data.Blog6, data.Blog7});
        }
    }
}
