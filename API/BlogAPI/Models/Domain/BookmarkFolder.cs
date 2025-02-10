using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("This class represents a bookmark folder.")]
    public class BookmarkFolder
    {
        [Comment("The unique identifier of the bookmark folder.")]
        [Key]
        public int Id { get; set; }

        [Comment("The name of the bookmark folder.")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Comment("The user identifier.")]
        public string UserId { get; set; } = string.Empty;

        [Comment("The user that owns the bookmark folder.")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("The bookmarks in the folder.")]
        public List<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

        [Comment("The date the bookmark folder was created.")]
        public DateTime CreationDate { get; set; }
    }
}
