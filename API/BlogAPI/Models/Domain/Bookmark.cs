using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Domain
{
    [Comment("Bookmark entity")]
    public class Bookmark
    {
        [Comment("Unique identifier for the bookmark")]
        [Key]
        public int Id { get; set; }

        [Comment("Blog identifier")]
        public int? BlogId { get; set; }

        [Comment("Navigation property to the blog that this bookmark belongs to")]
        [ForeignKey(nameof(BlogId))]
        public Blog? Blog { get; set; }

        [Comment("Author identifier (ApplicationUser ID)")]
        public string? AuthorId { get; set; }

        [Comment("Navigation property to the bookmarked author")]
        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser? Author { get; set; }

        [Comment("Date and time the bookmark was created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Comment("Folder identifier")]
        public int FolderId { get; set; }

        [Comment("Folder of the bookmark")]
        [ForeignKey(nameof(FolderId))]
        public BookmarkFolder? Folder { get; set; }
    }
}