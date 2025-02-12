using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Posts entity")]
    public class ForumPost
    {
        [Key]
        [Comment("Unique identifier for the post")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(400)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Comment("Community identifier")]
        public int ForumCommunityId { get; set; }

        [ForeignKey(nameof(ForumCommunityId))]
        [Comment("Navigation property to the community that this post belongs to")]
        public ForumCommunity ForumCommunity { get; set; } = null!;

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("Navigation property to the user that created this post")]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Comments of the post")]
        public List<ForumPostComment> Comments { get; set; } = new();

        [Comment("Votes of the post")]
        public int Votes { get; set; }

        [Comment("Image of the post")]
        public Images? Image { get; set; }
    }
}
