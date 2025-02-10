using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    [Comment("Stream entity")]
    public class Stream
    {
        [Comment("Unique identifier for the stream")]
        public int Id { get; set; }

        [Comment("Name of the stream")]
        public string Name { get; set; } = string.Empty;

        [Comment("Description of the stream")]
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [Comment("Navigation property to the category of the stream")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("URL handle for the stream")]
        public string Slug { get; set; } = string.Empty;

        [Comment("Owner of the stream")]
        public string OwnerId { get; set; } = string.Empty;
        [Comment("Navigation property to the owner of the stream")]
        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        [Comment("Image")]
        public Images Image { get; set; } = null!;
        [Comment("Max viewers count")]
        public int MaxViewers { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime When { get; set; }
        public string StreamKey { get; set; } = Guid.NewGuid().ToString(); 
        public string StreamUrl { get; set; } = "http://localhost:3000/live";
    }
}
