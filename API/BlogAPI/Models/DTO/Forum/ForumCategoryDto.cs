namespace BlogAPI.Models.DTO.Forum
{
    public class ForumCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MemberCount { get; set; }
        public int PostsCount { get; set; }
    }
}
