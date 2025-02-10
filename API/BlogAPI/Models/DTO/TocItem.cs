namespace BlogAPI.Models.DTO
{
    public class TocItem
    {
        public string title { get; set; } = string.Empty;
        public string anchor { get; set; } = string.Empty;
        public int level { get; set; }
    }
}
