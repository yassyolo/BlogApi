using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.Domain
{
    public class UserStream
    {
        [Comment("Primary key of the user stream")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user that this stream belongs to")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Primary key of the stream")]
        public int StreamId { get; set; }
        [ForeignKey(nameof(StreamId))]
        [Comment("Navigation property to the stream that this user belongs to")]
        public Stream Stream { get; set; } = null!;

    }
}
