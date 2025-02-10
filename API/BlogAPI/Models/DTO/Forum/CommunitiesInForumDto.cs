namespace BlogAPI.Models.DTO.Forum
{
    public class CommunitiesInForumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public int Members { get; set; }
    }
}
