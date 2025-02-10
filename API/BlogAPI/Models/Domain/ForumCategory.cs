using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Domain
{
    [Comment("Categories of the forum")]
    public class ForumCategory
    {
        [Key]
        [Comment("Identifier of the forum category")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Name of the forum category")]
        public string Name { get; set; } = string.Empty;

        [Comment("Communities that belong to this forum category")]
        public List<ForumCommunity> ForumCommunities { get; set; } = new();
    }
}
