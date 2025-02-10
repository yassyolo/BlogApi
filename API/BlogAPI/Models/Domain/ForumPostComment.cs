using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Comments on a forum post")]
    public class ForumPostComment
    {
        [Key]
        [Comment("Unique identifier for the comment")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; } = string.Empty;

        [Comment("Date and time the comment was created")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Comment("Forum post identifier")]
        public int ForumPostId { get; set; }

        [Comment("Navigation property to the forum post that this comment belongs to")]
        [ForeignKey(nameof(ForumPostId))]
        public ForumPost ForumPost { get; set; } = null!;

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that created this comment")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Navigation property to the user that created this comment")]
        public int Votes { get; set; } 
    }
}
