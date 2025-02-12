
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO.Stream;
using Stream = BlogAPI.Models.Domain.Stream;

namespace BlogAPI.Repositories.Interface
{
    public interface IStreamRepository
    {
        Task CreateStreamAsync(CreateStreamDto createStreamDto, string userId);
        Task DeleteStreamAsync(int id);
        Task<int> GetJoinedUsersAsync(int id);
        Task<Stream> GetStreamAsync(int id);
        Task<Stream> GetStreamForEditAsync(int id);
        Task<IEnumerable<Models.Domain.Stream>> GetStreamsAsync(string? query, int? categoryId);
        Task JoinStreamAsync(string userId, int id);
        Task LeaveStreamAsync(string userId, int id);
        Task<bool> StreamWithIdExistsAsync(int id);
        Task UpdateStreamAsync(int id, CreateStreamDto updateStreamDto);
        Task<bool> UserIsInStreamAsync(string userId, int id);
        Task<bool> UserIsOwnerOfStreamAsync(string userId, int id);
    }
}
