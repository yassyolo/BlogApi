using BlogAPI.Constants;
using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static BlogAPI.Constants.AchievementConstants;

namespace BlogAPI.Repositories.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IAchievementRepository achievementRepository;

        public CommentRepository(ApplicationDbContext context, IAchievementRepository achievementRepository)
        {
            this.context = context;
            this.achievementRepository = achievementRepository;
        }

        public async Task<bool> CommentExistsAsync(int blogId, int commentId)
        {
            return await context.Comments.AnyAsync(c => c.BlogPostId == blogId && c.Id == commentId);
        }

        public async Task CreateAsync(string userId, int blogId, string comment)
        {
            var userComments = await context.Comments.Where(c => c.UserId == userId).ToListAsync();
            switch(userComments.Count)
            {
                case 0:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, FirstComment);
                    break;
                case 10:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, ActiveDiscussant);
                    break;
                case 50:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, CommentMaster);
                    break;
                default:
                    await achievementRepository.IncrementUserAchievementsAsync(userId, FirstComment, ActiveDiscussant, CommentMaster);
                    break;

            }
            var newComment = new Comment
            {
                BlogPostId = blogId,
                UserId = userId,
                Content = comment,
                Likes = 0,
                CreatedDate = DateTime.Now
            };
            await context.Comments.AddAsync(newComment);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int blogId)
        {
            return await context.Comments.Include(x => x.User).Where(c => c.BlogPostId == blogId).ToListAsync();
        }

        public async Task LikeAsync(int commentId)
        {
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            comment.Likes++;
            await context.SaveChangesAsync();
        }

        public async Task<bool> UserLikedCommentAsync(int commentId, string userId)
        {
            return await context.Comments.AnyAsync(c => c.Id == commentId && c.UserId == userId);
        }
    }
}
