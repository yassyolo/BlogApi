namespace BlogAPI.Models.DTO.Forum
{
    public class ForumCommunitiesForFeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public string PostTitle { get; set; } = string.Empty;

        public string PostContent { get; set; } = string.Empty;
        public string PostImageUri { get; set; } = string.Empty;
    }
}
