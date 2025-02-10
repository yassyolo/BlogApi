namespace BlogAPI.Models.DTO.Forum
{
    public class CreateForumPostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public IFormFile? Image { get; set; } 
    }
}
