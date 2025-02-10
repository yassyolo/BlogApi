using BlogAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogAPI.Models.Domain
{
    [Comment("Blog post entity")]
    public class Blog
    {
        [Key]
        [Comment("Unique identifier for the blog post")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Title of the blog post")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Content of the blog post")]
        public string Content { get; set; } = string.Empty;

        [Comment("Date and time the blog post was created")]
        public DateTime CreationDate { get; set; }

        [Comment("Slug of the blog post")]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        [Comment("Author identifier")]
        public string AuthorId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that created this blog post")]
        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser Author { get; set; } = null!;

        [Comment("Number of views the blog post has")]
        public int ViewCount { get; set; }

        [Comment("Number of bookmarks the blog post has")]
        public int BookmarkCount { get; set; }

        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [Comment("Navigation property to the category that this blog post belongs to")]
        public Category Category { get; set; } = null!;

        [Comment("Comments of the blog post")]

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        [Comment("Images of the blog post")]
        public IEnumerable<Images> Images { get; set; } = new List<Images>();

        [Comment("Bookmarks of the blog post")]
        public IEnumerable<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

        [Comment("Table of contents for the blog post")]
        public string TocJson { get; set; } = "[]";

        [NotMapped]
        [JsonIgnore]
        public List<TocItem> Toc
        {
            get => string.IsNullOrEmpty(TocJson) ? new List<TocItem>() : JsonSerializer.Deserialize<List<TocItem>>(TocJson) ?? new List<TocItem>();
            set => TocJson = JsonSerializer.Serialize(value);
        }
    }
}
