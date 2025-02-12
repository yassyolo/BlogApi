using BlogAPI.Data;
using BlogAPI.Models.DTO.Stream;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class StreamRepository : IStreamRepository
    {
        private readonly ApplicationDbContext context;

        public StreamRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateStreamAsync(CreateStreamDto createStreamDto, string userId)
        {
            var stream = new Models.Domain.Stream
            {
                Name = createStreamDto.Name,
                Description = createStreamDto.Description,
                CategoryId = createStreamDto.CategoryId,
                OwnerId = userId,
                MaxViewers = createStreamDto.MaxViewers,
                When = createStreamDto.When,
                CreatedOn = DateTime.Now
            };

            await context.Streams.AddAsync(stream);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStreamAsync(int id)
        {
            var stream = await context.Streams.FirstOrDefaultAsync(x => x.Id == id);
            context.Streams.Remove(stream);
        }

        public async Task<int> GetJoinedUsersAsync(int id)
        {
            return await context.UserStreams.CountAsync(x => x.StreamId == id);
        }

        public async Task<Models.Domain.Stream> GetStreamAsync(int id)
        {
            return await context.Streams.Include(x => x.Category).Include(x => x.Image).Include(x => x.Owner).ThenInclude(x => x.ProfileImage).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domain.Stream> GetStreamForEditAsync(int id)
        {
            return await context.Streams.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Models.Domain.Stream>> GetStreamsAsync(string? query, int? categoryId)
        {
            var queryable = context.Streams.Include(x => x.Category).Include(x => x.Image).Include(x => x.Owner).ThenInclude(x => x.ProfileImage).AsQueryable();
            if (query != null)
            {
                queryable = queryable.Where(x => x.Description.Contains(query) 
                || x.Owner.FirstName.Contains(query)
                  || x.Owner.LastName.Contains(query)
                   || x.Category.Name.Contains(query)
                    || x.Name.Contains(query));
            }
            if (categoryId != null)
            {
                queryable = queryable.Where(x => x.CategoryId == categoryId);
            }

            return await queryable.ToListAsync();
        }

        public async Task JoinStreamAsync(string userId, int id)
        {
            var userStream = new Models.Domain.UserStream
            {
                StreamId = id,
                UserId = userId
            };

            await context.UserStreams.AddAsync(userStream);
            await context.SaveChangesAsync();
        }

        public async Task LeaveStreamAsync(string userId, int id)
        {
            var userStream = await context.UserStreams.FirstOrDefaultAsync(x => x.StreamId == id && x.UserId == userId);
            context.UserStreams.Remove(userStream);
            await context.SaveChangesAsync();
        }

        public async Task<bool> StreamWithIdExistsAsync(int id)
        {
            return await    context.Streams.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateStreamAsync(int id, CreateStreamDto updateStreamDto)
        {
            var stream = await context.Streams.FirstOrDefaultAsync(x => x.Id == id);
            stream.Name = updateStreamDto.Name;
            stream.Description = updateStreamDto.Description;
            stream.CategoryId = updateStreamDto.CategoryId;
            stream.MaxViewers = updateStreamDto.MaxViewers;
            stream.When = updateStreamDto.When;
            await context.SaveChangesAsync();

        }

        public async Task<bool> UserIsInStreamAsync(string userId, int id)
        {
            return await context.UserStreams.AnyAsync(x => x.StreamId == id && x.UserId == userId);
        }

        public async Task<bool> UserIsOwnerOfStreamAsync(string userId, int id)
        {
            return await context.Streams.AnyAsync(x => x.Id == id && x.OwnerId == userId);
        }
    }
}
