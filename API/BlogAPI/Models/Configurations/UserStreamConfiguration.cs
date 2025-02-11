using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Models.Configurations
{
    public class UserStreamConfiguration : IEntityTypeConfiguration<UserStream>
    {
        public void Configure(EntityTypeBuilder<UserStream> builder)
        {
            builder.HasKey(us => new { us.UserId, us.StreamId });
        }
    }
}
