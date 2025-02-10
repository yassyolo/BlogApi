using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories.Interface
{
    public interface IBlogImageRepository
    {
        Task Upload(IFormFile file, Images blogImage);
        Task<IEnumerable<Images>> GetAllAsync();
        Task CreateImages(List<IFormFile> images, string slug, int blogId);
    }
}
