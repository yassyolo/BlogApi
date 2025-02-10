using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Domain
{
    [Comment("This class represents a tag for a blog post.")]
    public class Tag
    {
        [Comment("The unique identifier of the tag.")]
        [Key]
        public int Id { get; set; }

        [Comment("The name of the tag.")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Comment("The URL handle for the tag.")]
        [Required]
        public string Slug { get; set; } = string.Empty;
    }
}
