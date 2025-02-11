namespace BlogAPI.Models.DTO.Forum
{
    public class ForumPostsForForumDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public string CommunityName { get; set; } = string.Empty;
        public string CommunityImageUri { get; set; } = string.Empty;
        public int CommunityId { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }       
        public string CreatedAt { get; set; } = string.Empty;
    }
}
