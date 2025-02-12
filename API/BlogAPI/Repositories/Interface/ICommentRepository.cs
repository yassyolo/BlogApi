
using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<bool> CommentExistsAsync(int blogId, int commentId);
        Task<Comment> CreateAsync(string userId, int blogId, string comment);
        Task<IEnumerable<Comment>> GetAllAsync(int blogId);
        Task LikeAsync(int commentId);
        Task<bool> UserLikedCommentAsync(int commentId, string userId);
    }
}
