namespace BlogAPI.Models.DTO.BlogPost
{
    public class BlogForDeleteDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int CommentsCount { get; set; }
        public int Views { get; set; }
        public int Bookmarks { get; set; }
    }
}
