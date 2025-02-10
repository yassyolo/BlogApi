namespace BlogAPI.Models.DTO.Forum
{
    public class ForumCommunityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        //public string CreatorId { get; set; } = string.Empty;
        public int Members { get; set; }
        public int PostsCount { get; set; }
        public string CreationDate { get; set; } = string.Empty;
        public List<string> Rules { get; set; } = new List<string>();
        public int Rank { get; set; }
    }
}
