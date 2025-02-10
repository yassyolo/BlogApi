using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);

        Task<Category?> GetCategoryByIdAsync(Guid id);

        Task<Category?> UpdateCategory(Category category);

        Task<Category?> DeleteCategory(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
