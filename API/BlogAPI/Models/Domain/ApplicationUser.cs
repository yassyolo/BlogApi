using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BlogAPI.Models.Domain
{
    [Comment("Application user entity")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("First name of the user")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last name of the user")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Comment("Description of the user")]
        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;

        [Comment("Profile image of the user")]
        public Images? ProfileImage { get; set; }

        [Comment("Navigation property to the blogs that this user has created")]
        public IEnumerable<Blog> Blogs { get; set; } = new List<Blog>();

        [Comment("Navigation property to the comments that this user has created")]
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        [Comment("Navigation property to the bookmarks that this user has created")]
        public IEnumerable<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

        [Comment("Navigation property to the bookmark folders that this user has created")]
        public IEnumerable<BookmarkFolder> BookmarkFolders { get; set; } = new List<BookmarkFolder>();

        [Comment("Navigation property to the forum posts that this user has created")]
        public IEnumerable<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();

        [Comment("Navigation property to the forum post comments that this user has created")]
        public IEnumerable<ForumPostComment> ForumPostComments { get; set; } = new List<ForumPostComment>();

        [Comment("Navigation property to the forum post comment replies that this user has created")]
        public IEnumerable<Stream> Streams { get; set; } = new List<Stream>();


        [Comment("Points of user")]
        public int Points { get; set; }
    }
}
