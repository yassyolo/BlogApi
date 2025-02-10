
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;

namespace BlogAPI.Repositories.Interface
{
    public interface IBookmarkRepository
    {
        Task AddToFolderAsync(BookmarkFolder bookmarkFolder, AddToFolderRequestDto request);
        Task CreateFolderAsync(CreateFolderDto request, string userId);
        Task DeleteFolderAsync(int folderId);
        Task<IEnumerable<BookmarkFolder?>> GetAllForUserAsync(string userId, string? query = null, string? sorting = null);
        Task<BookmarkFolder> GetFolderByIdAsync(int folderId);
        Task<IEnumerable<Bookmark>> GetFolderContentsByIdAsync(int folderId, string? query = null, string? sorting = null);
        Task IncrementUserBookmarkAchievementAsync(string userId);
    }
}
