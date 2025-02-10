using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("User achievement entity")]
    public class UserAchievement
    {
        [Comment("Primary key of the user achievement")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that this achievement belongs to")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Primary key of the achievement")]
        public int AchievementId { get; set; }

        [Comment("Navigation property to the achievement that this user has achieved")]
        [ForeignKey(nameof(AchievementId))]
        public Achievement Achievement { get; set; } = null!;

        [Comment("Flag indicating if the achievement is achieved")]
        public bool IsAchieved { get; set; }

        [Comment("Date and time the achievement was achieved")]
        public DateTime AchievementDate { get; set; }

        [Comment("Progress of the achievement")]
        public int Progress { get; set; }
    }
}
