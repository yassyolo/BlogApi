using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;

namespace BlogAPI.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<bool> BlogWithIdExistsAsync(int id);
        Task<int> CreateAsync(string userId, CreateBlogPostRequestDto request);
        Task<IEnumerable<Blog>> GetAllAsync(int? pageSize, int? currentPage, string? query = null, int? categoryId = null);
        Task<Blog> GetBlogWithIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsForBlogAsync(int id);
        Task<IEnumerable<Blog>> GetTopBlogsAsync(string? authorId);
        Task<IEnumerable<Blog>> GetTopRankingBlogsAsync(string? from = null);
        Task<int> GetTotalBlogsAsync(string? query, int? categoryId);
        Task IncrementViewCountAsync(string userId, int id);
    }
}
