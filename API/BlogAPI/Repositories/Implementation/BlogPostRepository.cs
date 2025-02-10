using static BlogAPI.Constants.AchievementConstants;
using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace BlogAPI.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IAchievementRepository achievementRepository;

        public BlogPostRepository(ApplicationDbContext context, IAchievementRepository achievementRepository)
        {
            this.context = context;
            this.achievementRepository = achievementRepository;
        }

        public async Task<bool> BlogWithIdExistsAsync(int id)
        {
            return await context.BlogPosts.AnyAsync(b => b.Id == id);
        }

        public async Task<int> CreateAsync(string userId, CreateBlogPostRequestDto request)
        {
            var blogsByUser = await context.BlogPosts.Where(b => b.AuthorId == userId).ToListAsync();
            switch(blogsByUser.Count()){
                case 0:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, FirstBlogPost);
                    break;
                case ContentCreatorConditionValue:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, ContentCreator);
                    break;
                default:
                    await achievementRepository.IncrementUserAchievementsAsync(userId, FirstBlogPost, ContentCreator);
                    break;
            }

            var blog = new Blog()
            {
                Title = request.Title,
                Content = request.Content,
                AuthorId = userId,
                CreationDate = DateTime.Now,
                CategoryId = request.CategoryId,
                Slug = request.Slug,
                ViewCount = 0,
                BookmarkCount = 0,
                TocJson = request.Toc
            };
            await context.BlogPosts.AddAsync(blog);
            await context.SaveChangesAsync();

            if(request.TagIds.Any())
            {
                foreach (var tagId in request.TagIds)
                {
                    var blogTag = new BlogPostTag
                    {
                        BlogId = blog.Id,
                        TagId = tagId
                    };
                    await context.BlogPostsTags.AddAsync(blogTag);
                    await context.SaveChangesAsync();
                }
            }

            if(request.NewTags.Any())
            {
                foreach(var tagId in request.NewTags)
                {
                    var tag = new Tag
                    {
                        Name = tagId
                    };
                    await context.Tags.AddAsync(tag);
                    await context.SaveChangesAsync();

                    var blogTag = new BlogPostTag
                    {
                        BlogId = blog.Id,
                        TagId = tag.Id
                    };
                    await context.BlogPostsTags.AddAsync(blogTag);
                    await context.SaveChangesAsync();
                }
            }

            return blog.Id;
        }
        
        public async Task<IEnumerable<Blog>> GetAllAsync(int? pageSize, int? currentPage, string? query = null, int? categoryId = null)
        {
            var queryable = context.BlogPosts.AsQueryable();

            if(!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(b => b.Title.Contains(query) || b.Content.Contains(query));
            }

            if(categoryId.HasValue)
            {
                queryable = queryable.Where(b => b.CategoryId == categoryId);
            }

            return await queryable.Include(x => x.Images).Skip((currentPage.Value - 1) * pageSize.Value).Take(pageSize.Value)  .ToListAsync();
        }

        public async Task<Blog> GetBlogWithIdAsync(int id)
        {
            return await context.BlogPosts.Include(x => x.Category).Include(x => x.Author).ThenInclude(x => x.ProfileImage).Include(x => x.Images).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Tag>> GetTagsForBlogAsync(int id)
        {
            return await context.BlogPostsTags.Include(x => x.Tag).Where(x => x.BlogId == id).Select(x => x.Tag).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetTopBlogsAsync(string? authorId)
        {
            var queryable = context.BlogPosts.AsQueryable();

            if(!string.IsNullOrEmpty(authorId))
            {
                queryable = queryable.Where(b => b.AuthorId == authorId);
            }

            return await queryable.Include(x => x.Images).Include(x => x.Comments).OrderByDescending(b => b.ViewCount).ThenByDescending(x => x.Comments.Count()).ThenByDescending(x => x.BookmarkCount).Take(6).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetTopRankingBlogsAsync(string? from = null)
        {
            var queryable = context.BlogPosts.Include(x => x.Author).Include(x => x.Category).Include(x => x.Images).Include(x => x.Comments).OrderByDescending(b => b.ViewCount).ThenByDescending(x => x.Comments.Count()).ThenByDescending(x => x.BookmarkCount).Take(10).AsQueryable();

            if(!string.IsNullOrEmpty(from))
            {
                switch(from)
                {
                    case "week":
                        queryable = queryable.Where(b => b.CreationDate >= DateTime.Now.AddDays(-7));
                        break;
                    case "month":
                        queryable = queryable.Where(b => b.CreationDate >= DateTime.Now.AddMonths(-1));
                        break;
                    case "year":
                        queryable = queryable.Where(b => b.CreationDate >= DateTime.Now.AddYears(-1));
                        break;
                }
            }

            return await queryable.ToListAsync();
        }

        public async Task<int> GetTotalBlogsAsync(string? query, int? categoryId)
        {
            var blogQuery = context.BlogPosts.AsQueryable();

            if(!string.IsNullOrEmpty(query))
            {
                blogQuery = blogQuery.Where(b => b.Title.Contains(query) || b.Content.Contains(query));
            }   

            if(categoryId.HasValue)
            {
                blogQuery = blogQuery.Where(b => b.CategoryId == categoryId);
            }

            return await blogQuery.CountAsync();
        }

        public async Task IncrementViewCountAsync(string userId, int id)
        {
            var blog = await context.BlogPosts.FindAsync(id);
            var userReadBlog = await context.UserReadBlogs.FirstOrDefaultAsync(urb => urb.UserId == userId && urb.BlogId == id);
            if(userReadBlog == null)
            {
                blog.ViewCount++;

                userReadBlog = new UserReadBlog
                {
                    UserId = userId,
                    BlogId = id,
                };
                await context.UserReadBlogs.AddAsync(userReadBlog);

                var userAchievements = await context.UserAchievements.Include(x => x.Achievement).Where(ua => ua.UserId == userId).ToListAsync();
                switch (userAchievements.Count())
                {
                    case 0:
                        await achievementRepository.CreateNewUserAchievementAsync(userId, FirstBlogRead);
                        break;
                    case BookwormConditionValue:
                        await achievementRepository.CreateNewUserAchievementAsync(userId, Bookworm);
                        break;
                    case SuperReaderConditionValue:
                        await achievementRepository.CreateNewUserAchievementAsync(userId, SuperReader);
                        break;
                    default:
                        await achievementRepository.IncrementUserAchievementsAsync(userId, FirstBlogRead, Bookworm, SuperReader);
                        break;
                }

                foreach(var ua in userAchievements)
                {
                    if(ua.Progress < ua.Achievement.ConditionValue)
                    {
                        ua.Progress++;
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
