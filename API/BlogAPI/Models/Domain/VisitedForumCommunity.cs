using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Visited forum community entity")]
    public class VisitedForumCommunity
    {
        [Comment("Id of the user visited forum community")]
        public string UserId { get; set; }

        [Comment("Navigation property to the user that visited the forum community")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Id of the forum community visited by the user")]
        public int ForumCommunityId { get; set; }
        [Comment("Navigation property to the forum community visited by the user")]
        [ForeignKey(nameof(ForumCommunityId))]
        public ForumCommunity ForumCommunity { get; set; } = null!;

        public DateTime LastVisited { get; set; }
        public int Visits { get; set; }
    }
}
