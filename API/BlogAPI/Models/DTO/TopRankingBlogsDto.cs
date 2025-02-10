namespace BlogAPI.Models.DTO
{
    public class TopRankingBlogsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public int CommentsCount { get; set; }  
        public int ReadingsCount { get; set;}
        public int BookmarksCount { get; set;}
    }
}
