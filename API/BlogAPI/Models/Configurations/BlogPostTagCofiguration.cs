using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class BlogPostTagCofiguration : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.HasKey(x => new {x.BlogId, x.TagId});
            var data = new SeedData();
            builder.HasData(new BlogPostTag[] {data.BlogPostTag1, data.BlogPostTag2, data.BlogPostTag3, data.BlogPostTag4, data.BlogPostTag5, data.BlogPostTag6, data.BlogPostTag7, data.BlogPostTag8, data.BlogPostTag9, data.BlogPostTag10, data.BlogPostTag11, data.BlogPostTag12, data.BlogPostTag13, data.BlogPostTag14});
        }
    }
}
