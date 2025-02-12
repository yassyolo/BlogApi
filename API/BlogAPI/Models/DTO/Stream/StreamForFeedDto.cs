namespace BlogAPI.Models.DTO.Stream
{
    public class StreamForFeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string OwnerImageUrl { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public int ViewersCount { get; set; }
        public int ViwersLimit { get; set; }
        public string When { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
    }
}
