namespace BlogAPI.Models.DTO
{
    public class CreateFolderDto
    {
        public string Name { get; set; } = string.Empty;
        public string? AuthorId { get; set; }
        public int? BlogId { get; set; }
    }
}
