using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("This class represents a blog image.")]
    public class Images
    {
        [Comment("The unique identifier of the blog image.")]
        [Key]
        public int Id { get; set; }

        [Comment("The name of the file.")]
        public string FileName { get; set; } = string.Empty;

        [Comment("The file extension of the image.")]
        public string FileExtension { get; set; } = string.Empty;

        [Comment("The title of the image.")]
        public string Title { get; set; } = string.Empty;

        [Comment("The URL of the image.")]
        public string Url { get; set; } = string.Empty;

        [Comment("The date the image was created.")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Comment("The blog post identifier.")]
        public int? BlogId { get; set; }

        [Comment("Navigation property to the blog post that this image belongs to.")]
        [ForeignKey(nameof(BlogId))]
        public Blog? Blog { get; set; }

        [Comment("The user identifier.")]
        public string? UserId { get; set; }

        [Comment("Navigation property to the user that uploaded this image.")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        [Comment("The achievement identifier.")]
        public int? AchievementId { get; set; }

        [Comment("Navigation property to the achievement that this image belongs to.")]
        [ForeignKey(nameof(AchievementId))]
        public Achievement? Achievement { get; set; } = null!;

        [Comment("The forum post identifier.")]
        public int? ForumPostId { get; set; }

        [Comment("Navigation property to the forum post that this image belongs to.")]
        [ForeignKey(nameof(ForumPostId))]
        public ForumPost? ForumPost { get; set; } = null!;

        [Comment("The forum comment identifier.")]
        public int? ForumCommunityId { get; set; }

        [Comment("Navigation property to the forum comment that this image belongs to.")]
        [ForeignKey(nameof(ForumCommunityId))]
        public ForumCommunity? ForumCommunity { get; set; } = null!;
    }
}
