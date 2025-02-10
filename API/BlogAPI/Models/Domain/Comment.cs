using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Comment entity")]
    public class Comment
    {
        [Key]
        [Comment("Unique identifier for the comment")]
        public int Id { get; set; }

        [Required]
        [Comment("Content of the comment")]
        public string Content { get; set; } = string.Empty;

        [Comment("Date and time the comment was created")]
        public DateTime CreatedDate { get; set; }

        [Comment("Blog post identifier")]
        public int BlogPostId { get; set; }

        [Comment("Navigation property to the blog post that this comment belongs to")]
        [ForeignKey(nameof(BlogPostId))]
        public Blog BlogPost { get; set; } = null!;

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that created this comment")]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Number of likes the comment has")]
        public int Likes { get; set; }
    }
}
