
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO.Forum;

namespace BlogAPI.Repositories.Interface
{
    public interface IForumRepository
    {
        Task<bool> CommentExistsAsync(int commentId);
        Task<bool> CommunityWithIdExistsAsync(int id);
        Task<ForumPostComment> CreateCommentAsync(string userId, int id, string comment);
        Task CreatePostAsync(string userId, int id, CreateForumPostDto post);
        Task DeletePostAsync(int postId);
        Task DownVoteCommentAsync(string userId, int commentId);
        Task<bool> ForumCategoryWithIdExistsAsync(int id);
        Task<IEnumerable<ForumCategory>> GetAllCategoriesAsync();
        Task<IEnumerable<ForumCommunity>> GetCommunitiesForFeedAsync();
        Task<IEnumerable<ForumCommunity>> GetCommunitiesInCategoryAsync(int categoryId);
        Task<ForumCommunity> GetCommunityAsync(int id);
        Task<int> GetCommunityRankAsync(int id);
        Task<IEnumerable<ForumPost>> GetFeedAsync(string? sorting, int? forumId, int? categoryId);
        Task<ForumCategory> GetForumCategoryAsync(int id);
        Task<IEnumerable<ForumCommunity>> GetLastVisitedCommunitiesAsync();
        Task<IEnumerable<ForumCommunity>> GetMostPopularCommunitiesAsync();
        Task<ForumPost> GetPostAsync(int id);
        Task JoinCommunityAsync(string userId, int id);
        Task LeaveCommunityAsync(string userId, int id);
        Task<bool> PostExistsAsync(int postId);
        Task<bool> UserIsAuthorOfPostAsync(string userId, int postId);
        Task<bool> UserIsMemberOfCommunityAsync(string userId, int id);
        Task VoteCommentAsync(string userId, int commentId);
    }
}
