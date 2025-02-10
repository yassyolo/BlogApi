using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class UserReadBlogConfiguration : IEntityTypeConfiguration<UserReadBlog>
    {
        public void Configure(EntityTypeBuilder<UserReadBlog> builder)
        {
            builder.HasKey(x => new { x.UserId, x.BlogId });
        }
    }
}
