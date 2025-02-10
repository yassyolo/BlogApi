using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Domain
{
    [Comment("Category entity")]
    public class Category
    {
        [Key]
        [Comment("Unique identifier for the category")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Name of the category")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Comment("URL handle for the category")]
        public string Slug { get; set; } = string.Empty;

        [Comment("Navigation property to the blog posts that belong to this category")]
        public IEnumerable<Blog> BlogPosts { get; set; } = new List<Blog>();

        [Comment("Navigation property to the streams that belong to this category")]
        public IEnumerable<Stream> StreamPosts { get; set; }= new List<Stream>();

    }
}
