
using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories.Interface
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
