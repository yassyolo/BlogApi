
using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories.Interface
{
    public interface IAchievementRepository
    {
        Task CreateNewUserAchievementAsync(string userId, string superReader);
        Task<IEnumerable<UserAchievement>> GetAllForUserAsync(string userId);
        Task<(int Rank, int Points, int TotalUsers)> GetRankAsync(string userId);
        Task<IEnumerable<ApplicationUser>> GetTopUsersAsync();
        Task IncrementUserAchievementsAsync(string userId, params string[] achievementNames);
    }
}
