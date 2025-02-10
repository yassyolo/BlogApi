namespace BlogAPI.Models.DTO
{
    public class AchievementDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ConditionType { get; set; }
        public int ConditionValue { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public double Progress { get; set; }
    }
}
