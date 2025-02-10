namespace BlogAPI.Models.DTO
{
    public class BookmarkFolderIndexDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BookmarkCount { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
    }
}
