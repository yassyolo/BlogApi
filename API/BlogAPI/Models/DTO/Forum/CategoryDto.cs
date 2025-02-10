namespace BlogAPI.Models.DTO.Forum
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public int PostsCount { get; set; }
        public ForumPostsForFeedDto[] Posts { get; set; } = new ForumPostsForFeedDto[] { };
    }
}
