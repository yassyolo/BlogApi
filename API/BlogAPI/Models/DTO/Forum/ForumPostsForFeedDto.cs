namespace BlogAPI.Models.DTO.Forum
{
    public class ForumPostsForFeedDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public int CommentsCount { get; set; }
        public int Votes { get; set; }
        public string CommunityName { get; set; } = string.Empty;
        public string CommunityImageUri { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorImageUri { get; set; } = string.Empty;
    }
}
