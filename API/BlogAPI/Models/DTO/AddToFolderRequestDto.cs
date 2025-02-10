namespace BlogAPI.Models.DTO
{
    public class AddToFolderRequestDto
    {
        public int FolderId { get; set; }
        public int? BlogId { get; set; }
        public string? AuthorId { get; set; }
    }
}
