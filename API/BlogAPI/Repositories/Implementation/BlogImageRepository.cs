using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.Implementation
{
    public class BlogImageRepository : IBlogImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext context;

        public BlogImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, 
            ApplicationDbContext context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }

        public async Task CreateImages(List<IFormFile> images, string slug, int id)
        {
            var cnt = 0;

            foreach (var image in images)
            {
                cnt++;
                var newImage = new Images
                {
                    FileName = $"{slug}-{cnt}",
                    FileExtension = Path.GetExtension(image.FileName),
                    DateCreated = DateTime.Now,
                    Title = slug, 
                    BlogId = id
                };
                await Upload(image, newImage);
            }
        }

        public async Task<IEnumerable<Images>> GetAllAsync()
        {
            return await context.Images.ToListAsync();
        }

        public async Task Upload(IFormFile file, Images blogImage)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using (var stream = new FileStream(localPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var requestPath = httpContextAccessor.HttpContext.Request;
            var url = $"{requestPath.Scheme}://{requestPath.Host}{requestPath.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";

            blogImage.Url = url;

            await context.Images.AddAsync(blogImage);
            await context.SaveChangesAsync();
        }
    }
}
