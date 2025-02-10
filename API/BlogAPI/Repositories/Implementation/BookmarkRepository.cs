using BlogAPI.Constants;
using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static BlogAPI.Constants.AchievementConstants;

namespace BlogAPI.Repositories.Implementation
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IAchievementRepository achievementRepository;

        public BookmarkRepository(ApplicationDbContext context, IAchievementRepository achievementRepository)
        {
            this.context = context;
            this.achievementRepository = achievementRepository;
        }

        public async Task AddToFolderAsync(BookmarkFolder bookmarkFolder, AddToFolderRequestDto request)
        {            
            var bookmark = new Bookmark
            {
                BlogId = request.BlogId.HasValue ? request.BlogId : null ,
                AuthorId = string.IsNullOrEmpty(request.AuthorId) ? null : request.AuthorId,
                FolderId = bookmarkFolder.Id,
                CreatedAt = DateTime.Now
            };

            await context.Bookmarks.AddAsync(bookmark);
            await context.SaveChangesAsync();
        }

        public async Task CreateFolderAsync(CreateFolderDto request, string userId)
        {
            var newFolder = new BookmarkFolder
            {
                Name = request.Name,
                UserId = userId,
                CreationDate = DateTime.Now
            };

            await context.BookmarkFolders.AddAsync(newFolder);
            await context.SaveChangesAsync();

            var bookmark = new Bookmark
            {
                BlogId = request.BlogId.HasValue ? request.BlogId : null,
                AuthorId = string.IsNullOrEmpty(request.AuthorId) ? null : request.AuthorId,
                FolderId = newFolder.Id,
                CreatedAt = DateTime.Now
            };

            await context.Bookmarks.AddAsync(bookmark);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            var folder = await context.BookmarkFolders.Include(x => x.Bookmarks).FirstOrDefaultAsync(x => x.Id ==folderId);
            context.Bookmarks.RemoveRange(folder.Bookmarks);
            context.BookmarkFolders.Remove(folder);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookmarkFolder?>> GetAllForUserAsync(string userId, string? query = null, string? sorting = null)
        {
            var queryable = context.BookmarkFolders.Include(x => x.Bookmarks)
                .ThenInclude(x => x.Blog)
                .ThenInclude(x => x.Images)
                .Include(x => x.Bookmarks)
                .ThenInclude(x => x.Author)
                .ThenInclude(x => x.ProfileImage)
                .Where(x => x.UserId == userId).AsQueryable();

            if(!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(x =>
                    x.Name.Contains(query) ||
                    x.Bookmarks.Any(b => b.Author.FirstName.Contains(query) || b.Author.LastName.Contains(query)) ||
                    x.Bookmarks.Any(b => b.Blog.Title.Contains(query) || b.Blog.Content.Contains(query))
                );
            }

            if (!string.IsNullOrEmpty(sorting))
            {
                switch (sorting)
                {
                        case "nameAsc":
                        queryable = queryable.OrderBy(x => x.Name);
                        break;
                        case "nameDesc":
                            queryable = queryable.OrderByDescending(x => x.Name);
                        break;
                        case "dateAsc":
                        queryable = queryable.OrderBy(x => x.CreationDate);
                        break;
                        case "dateDesc":
                        queryable = queryable.OrderByDescending(x => x.CreationDate);
                        break;
                }
            }
            return await queryable.ToListAsync();
        }

        public async Task<BookmarkFolder> GetFolderByIdAsync(int folderId)
        {
            return await context.BookmarkFolders.Include(x => x.Bookmarks).Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == folderId);
        }

        public async Task<IEnumerable<Bookmark>> GetFolderContentsByIdAsync(int folderId, string? query = null, string? sorting = null)
        {
            var queryable = context.Bookmarks
                .Include(x => x.Folder)
                .Include(x => x.Blog)
                .ThenInclude(x => x.Images)                
                .Include(x => x.Author)
                .ThenInclude(x => x.ProfileImage)
                .Where(x => x.Id == folderId).AsQueryable();

            if(!string.IsNullOrEmpty(query))
            {
                query = query.ToLower();
                queryable = queryable.Where(x => x.Blog.Title.Contains(query) 
                            || x.Blog.Content.Contains(query) 
                            || x.Author.FirstName.Contains(query)
                            || x.Author.LastName.Contains(query)
                            || x.Author.UserName.Contains(query));
            }

            if (!string.IsNullOrEmpty(sorting))
            {
                switch (sorting)
                {
                    case "titleAsc":
                        queryable = queryable.OrderBy(x => x.Blog.Title);
                        break;
                    case "titleDesc":
                        queryable = queryable.OrderByDescending(x => x.Blog.Title);
                        break;
                    case "dateAsc":
                        queryable = queryable.OrderBy(x => x.CreatedAt);
                        break;
                    case "dateDesc":
                        queryable = queryable.OrderByDescending(x => x.CreatedAt);
                        break;
                    case "authorAsc":
                        queryable = queryable.OrderBy(x => x.Author.FirstName).ThenBy(x => x.Author.LastName);
                        break;
                    case "authorDesc":
                        queryable = queryable.OrderByDescending(x => x.Author.FirstName).ThenByDescending(x => x.Author.LastName);
                        break;
                }
            }
            return await queryable.ToListAsync();
        }

        public async Task IncrementUserBookmarkAchievementAsync(string userId)
        {
            var userAchievements = await context.UserAchievements.Where(x => x.UserId == userId).ToListAsync();
            switch(userAchievements.Count)
            {
                case 0:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, FirstBookmark);
                    break;
                case OrganizerConditionValue:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, Organizer);
                    break;
                case BookwormConditionValue:
                    await achievementRepository.CreateNewUserAchievementAsync(userId, BookmarkMaster);
                    break;
                default:
                    await achievementRepository.IncrementUserAchievementsAsync(userId, FirstBookmark, Organizer, BookmarkMaster);
                    break;
            }
        }
    }
}
