namespace BlogAPI.Models.DTO
{
    public class PagedResponseDto
    {
        public IEnumerable<BlogIndexDto> Data { get; set; } = new List<BlogIndexDto>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
