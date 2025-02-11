using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogAPI.Models.Domain
{
    [Comment("Communities within a category")]
    public class ForumCommunity
    {
        [Key]
        [Comment("Unique identifier for the community")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        [Required]
        public string Slug { get; set; } = string.Empty;

        [Comment("Category identifier")]
        public int ForumCategoryId { get; set; }

        [Comment("Navigation property to the category that this community belongs to")]
        [ForeignKey(nameof(ForumCategoryId))]
        public ForumCategory ForumCategory { get; set; } = null!;

        public Images Image { get; set; } = null!;

        [Comment("Posts within the community")]
        public IEnumerable<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();

        [Comment("Users within the community")]
        public IEnumerable<UserForumCommuntity> UserForumCommunities { get; set; } = new List<UserForumCommuntity>();

        [Comment("Date and time the community was created")]
        public DateTime Joined { get; set; }

        [Comment("Rules of the community")]
        public string RulesJson { get; set; } = string.Empty;

        [NotMapped]
        [JsonIgnore]
        public List<string> Rules
        {
            get => JsonSerializer.Deserialize<List<string>>(RulesJson);
            set => RulesJson = JsonSerializer.Serialize(value);
        }
    }
}
