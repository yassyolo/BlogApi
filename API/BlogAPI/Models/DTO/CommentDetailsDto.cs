namespace BlogAPI.Models.DTO
{
    public class CommentDetailsDto
    {
        public int Id { get; set; } 
        public string Date { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorImageUri { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Likes { get; set; }
    }
}
