using BlogAPI.Models.Domain;
using BlogAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {

        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            var data = new SeedData();
            builder.HasData(new Tag[] {data.Tag1, data.Tag2, data.Tag3, data.Tag4, data.Tag5, data.Tag6, data.Tag7, data.Tag8, data.Tag9, data.Tag10});
        }
    }
}
