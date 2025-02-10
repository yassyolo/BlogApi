using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly ApplicationDbContext context;

        public AchievementRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateNewUserAchievementAsync(string userId, string achievementName)
        {
            var userAchievement = await context.UserAchievements.Include(x => x.Achievement).FirstOrDefaultAsync(ua => ua.UserId == userId && ua.Achievement.Name == achievementName);
            if (userAchievement != null)
            {
                userAchievement.AchievementDate = DateTime.Now;
                userAchievement.IsAchieved = true;
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                user.Points += userAchievement.Achievement.Points;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserAchievement>> GetAllForUserAsync(string userId)
        {
            return await context.UserAchievements.Include(x => x.User).Include(x => x.Achievement).ThenInclude(x => x.Images).Where(ua => ua.UserId == userId).ToListAsync();
        }

        public async Task<(int Rank, int Points, int TotalUsers)> GetRankAsync(string userId)
        {
            var totalUsers = await context.Users.CountAsync();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var rank = await context.Users.CountAsync(u => u.Points > user.Points);
            var myPoints = user.Points;
            return (rank + 1, myPoints, totalUsers);
        }

        public async Task<IEnumerable<ApplicationUser>> GetTopUsersAsync()
        {
            return await context.Users.Include(x => x.ProfileImage).OrderByDescending(u => u.Points).Take(10).ToListAsync();
        }

        public async Task IncrementUserAchievementsAsync(string userId, params string[] achievementNames)
        {
            var userAchievements = await context.UserAchievements.Include(x => x.Achievement).Where(ua => ua.UserId == userId && achievementNames.Contains(ua.Achievement.Name)).ToListAsync();
            foreach (var userAchievement in userAchievements)
            {
                if(userAchievement.Progress == userAchievement.Achievement.ConditionValue)
                {
                    continue;
                }

                if(userAchievement.Progress < userAchievement.Achievement.ConditionValue)
                {
                    userAchievement.Progress++;
                    await context.SaveChangesAsync();
                }

                if (userAchievement.Progress == userAchievement.Achievement.ConditionValue && userAchievement.IsAchieved == false)
                {
                    userAchievement.AchievementDate = DateTime.Now;
                    userAchievement.IsAchieved = true;
                }
            }
        }
    }
}
