using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext context;

        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await context.Tags.ToListAsync();
        }
    }
}
