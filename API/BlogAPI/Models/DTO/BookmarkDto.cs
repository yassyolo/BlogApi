namespace BlogAPI.Models.DTO
{
    public class BookmarkDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public int? BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImageUrl { get; set; }
        public string? BlogContent { get; set; } 
        public string? AuthorId { get; set; } 
        public string? AuthorName { get; set; } 
        public string? AuthorUsername { get; set; }
        public int? AuthorCommentsCount { get; set; }
        public int? AuthorBookmarksCount { get; set; }
        public string? AuthorDescription { get; set; }
        public string? AuthorImageUrl { get; set; } 
    }
}
