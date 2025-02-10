namespace BlogAPI.Models.DTO
{
    public class TopUserPointsDto
    {  
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Points { get; set; }
        public string ImageUri { get; set; } = string.Empty;
    }
}
