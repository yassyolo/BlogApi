using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models.Domain
{
    [Comment("Tags of the blog post")]
    public class BlogPostTag
    {
       
        [Comment("Primary key of the blog post tag")]
        public int BlogId { get; set; }

        [Comment("Navigation property to the blog post that this tag belongs to")]
        public Blog Blog { get; set; } = null!;

        [Comment("Primary key of the tag")]
        public int TagId { get; set; }

        [Comment("Navigation property to the tag that this blog post belongs to")]
        public Tag Tag { get; set; } = null!;
    }
}
