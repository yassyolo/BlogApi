namespace BlogAPI.Models.DTO.BlogPost
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string[] Images { get; set; } = new string[] { };
        public List<TocItem> Toc { get; set; } = new List<TocItem>();
        public string Date { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorDescription { get; set; } = string.Empty;
        public string AuthorImageUri { get; set; } = string.Empty;
        public List<CommentDetailsDto> Comments { get; set; } = new List<CommentDetailsDto>();
        public int Bookmarks { get; set; }

    }
}
