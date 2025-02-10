using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.Domain
{
    [Comment("Achievement entity")]
    public class Achievement
    {
        [Key]
        [Comment("Unique identifier for the achievement")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Name of the achievement")]
        public string Name { get; set; } = string.Empty;

        [Comment("Image of the achievement")]
        public Images Images { get; set; } = null!;

        [Comment("Description of the achievement")]
        public string Description { get; set; } = string.Empty;

        [Comment("Condition type of the achievement")]
        public int ConditionType { get; set; }

        [Comment("Condition value of the achievement")]
        public int ConditionValue { get; set; }

        [Comment("Points of the achievement")]
        public int Points { get; set; }
    }
}
