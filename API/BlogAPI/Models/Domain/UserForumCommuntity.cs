using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("User community entity")]
    public class UserForumCommuntity
    {
        [Comment("User's unique identifier")]   
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that belongs to this community")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Community's unique identifier")]
        public int ForumCommunityId { get; set; }

        [Comment("Navigation property to the community that this user belongs to")]
        [ForeignKey(nameof(ForumCommunityId))]
        public ForumCommunity ForumCommunity { get; set; } = null!;
    }
}
