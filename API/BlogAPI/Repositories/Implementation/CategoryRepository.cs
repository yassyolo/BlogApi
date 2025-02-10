using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteCategory(Guid id)
        {
            var existingCategory = await context.Categories.FindAsync(id);

            if(existingCategory != null)
            {
                context.Categories.Remove(existingCategory);
                await context.SaveChangesAsync();
                return existingCategory;
            }

            return null;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await context.Categories.Take(10).ToListAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            var existingCategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory != null)
            {
                context.Entry(existingCategory).CurrentValues.SetValues(category);  
                await context.SaveChangesAsync();
                return category;
            }

            return null;
        }
    }
}
