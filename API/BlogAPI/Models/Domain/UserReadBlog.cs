using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Reading entity")]
    public class UserReadBlog
    {
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Blog identifier")]
        public int BlogId { get; set; }
        [Comment("Blog")]
        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; } = null!;

        [Required]
        [Comment("Reading date")]
        public DateTime Date { get; set; }
    }
}
