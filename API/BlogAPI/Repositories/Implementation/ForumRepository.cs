using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO.Forum;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class ForumRepository : IForumRepository
    {
        private readonly ApplicationDbContext context;

        public ForumRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CommunityWithIdExistsAsync(int id)
        {
            return await context.ForumCommunities.AnyAsync(x => x.Id == id);
        }

        public async Task CreatePostAsync(string userId, int id, CreateForumPostDto post)
        {
            var forumPost = new ForumPost
            {
                Title = post.Title,
                Content = post.Content,
                ForumCommunityId = id,
                UserId = userId,
                CreatedAt = DateTime.Now,
            };
            await context.ForumPosts.AddAsync(forumPost);
            await context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await context.ForumPosts.FirstOrDefaultAsync(x => x.Id == postId);
            context.ForumPosts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ForumCategoryWithIdExistsAsync(int id)
        {
            return await context.ForumCategories.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ForumCategory>> GetAllCategoriesAsync()
        {
            return await context.ForumCategories.ToListAsync();
        }

        public async Task<IEnumerable<ForumCommunity>> GetCommunitiesForFeedAsync()
        {
            return await context.ForumCommunities.Include(x => x.ForumPosts).Include(x => x.Image).Where(x => x.ForumPosts != null).OrderByDescending(x => x.UserForumCommunities.Count()).Take(7).ToListAsync();
        }

        public async Task<ForumCommunity> GetCommunityAsync(int id)
        {
            return await context.ForumCommunities.Include(x => x.Image).Include(x => x.UserForumCommunities).Include(x => x.ForumCategory)
                .Include(x => x.ForumPosts).ThenInclude(x => x.Image)
                .Include(x => x.ForumPosts).ThenInclude(x => x.User).ThenInclude(x => x.ProfileImage)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCommunityRankAsync(int id)
        {
            var community = await context.ForumCommunities.Include(x => x.UserForumCommunities).FirstOrDefaultAsync(x => x.Id == id);
            return await context.ForumCommunities.Include(x => x.UserForumCommunities).CountAsync(x => x.UserForumCommunities.Count() > community.UserForumCommunities.Count());
        }

        public async Task<IEnumerable<ForumPost>> GetFeedAsync(string? sorting, int? forumId, int? categoryId)
        {
            var queryable = context.ForumPosts
                .Include(x => x.ForumCommunity).ThenInclude(x => x.ForumCategory)
                .Include(x => x.ForumCommunity).ThenInclude(x => x.Image).Include(x => x.Image).AsQueryable();
            if (forumId != null)
            {
                queryable = queryable.Where(x => x.ForumCommunityId == forumId);
            }
            if (categoryId != null)
            {
                queryable = queryable.Where(x => x.ForumCommunity.ForumCategoryId == categoryId);
            }
            if(!string.IsNullOrEmpty(sorting))
            {
                switch(sorting)
                {
                    case "newest":
                        queryable = queryable.OrderByDescending(x => x.CreatedAt);
                        break;
                    case "dateAsc":
                        queryable = queryable.OrderBy(x => x.CreatedAt);
                        break;
                    case "most-voted":
                        queryable = queryable.OrderByDescending(x => x.Votes);
                        break;
                    case "most-commented":
                        queryable = queryable.OrderByDescending(x => x.Comments.Count());
                        break;
                    default:
                        queryable = queryable.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }
            return await queryable.ToListAsync();
        }

        public async Task<ForumCategory> GetForumCategoryAsync(int id)
        {
            return await context.ForumCategories.Include(x => x.ForumCommunities).ThenInclude(x => x.UserForumCommunities).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ForumCommunity>> GetLastVisitedCommunitiesAsync()
        {
            return await context.ForumCommunities.ToListAsync();
        }

        public async Task<IEnumerable<ForumCommunity>> GetMostPopularCommunitiesAsync()
        {
            return await context.ForumCommunities.Include(x => x.UserForumCommunities).OrderByDescending(x => x.UserForumCommunities.Count()).Take(6).ToListAsync();
        }

        public async Task JoinCommunityAsync(string userId, int id)
        {
            var userCommunity = new UserForumCommuntity
            {
                UserId = userId,
                ForumCommunityId = id
            };

            await context.UserForumCommuntities.AddAsync(userCommunity);
            await context.SaveChangesAsync();
        }

        public async Task LeaveCommunityAsync(string userId, int id)
        {
            var userCommunity = await context.UserForumCommuntities.FirstOrDefaultAsync(x => x.UserId == userId && x.ForumCommunityId == id);
            context.UserForumCommuntities.Remove(userCommunity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> PostExistsAsync(int postId)
        {
            return await context.ForumPosts.AnyAsync(x => x.Id == postId);
        }

        public async Task<bool> UserIsAuthorOfPostAsync(string userId, int postId)
        {
            return await context.ForumPosts.AnyAsync(x => x.UserId == userId && x.Id == postId);
        }

        public async Task<bool> UserIsMemberOfCommunityAsync(string userId, int id)
        {
            return await context.UserForumCommuntities.AnyAsync(x => x.UserId == userId && x.ForumCommunityId == id);
        }
    }
}
