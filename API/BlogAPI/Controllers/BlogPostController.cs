using BlogAPI.Extensions;
using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;
using BlogAPI.Models.DTO.BlogPost;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITokenRepository tokenRepository;
        private readonly IBlogImageRepository imageRepository;

        public BlogPostController(IBlogPostRepository blogPostRepository, ITokenRepository tokenRepository, IBlogImageRepository imageRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.tokenRepository = tokenRepository;
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] string? query,
            [FromQuery] int? categoryId,
            [FromQuery] int? pageSize,
            [FromQuery] int? currentPage)
        {
            var response = new PagedResponseDto
            {
                PageSize = pageSize ?? 2,
                CurrentPage = currentPage ?? 1,
            };
            var totalBlogs = await blogPostRepository.GetTotalBlogsAsync(query, categoryId);

            var filteredBlogs = await blogPostRepository.GetAllAsync(pageSize, currentPage, query, categoryId);

            var blogDto = filteredBlogs.Select(b => new BlogIndexDto
            {
                Id = b.Id,
                Title = b.Title,
                Slug = b.Slug,
                Content = b.Content,
                Date = b.CreationDate.ToString("dd-MM-yyyy"),
                ImageUri = b.Images.Select(x => x.Url).FirstOrDefault(), 
            }).ToList();

            var totalPages = (int)Math.Ceiling((double)totalBlogs / pageSize ?? 2);


            response.Data = blogDto;
            response.TotalPages = totalPages;

            return Ok(response);
        }
    

        [HttpGet]
        [Route("top-blogs")]
        public async Task<IActionResult> GetTopBlogs([FromQuery] string? authorId)
        {
            var blogs = await blogPostRepository.GetTopBlogsAsync(authorId);

            var response = blogs.Select(x => new TopBlogsDto()
            {
                Slug = x.Slug,
                Title = x.Title,
                Date = x.CreationDate.ToString("dd-MM-yyyy"),
                ImageUri = x.Images.Select(x => x.Url).First(),
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] CreateBlogPostRequestDto request)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            }

            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            var blogId = await blogPostRepository.CreateAsync(userId, request);

            if(request.Images != null)
            {
                ValidateImages(request.Images);
                await imageRepository.CreateImages(request.Images, request.Slug, blogId);
            }

            return Ok();
        }

        private void ValidateImages(List<IFormFile> file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            foreach (var image in file)
            {
                if (image.Length > 1048576)
                {
                    ModelState.AddModelError("Images", "File size is too large");
                }
                if (!allowedExtensions.Contains(Path.GetExtension(image.FileName).ToLower()))
                {
                    ModelState.AddModelError("Images", "Invalid file type");
                }
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            if(await blogPostRepository.BlogWithIdExistsAsync(id)== false)
            {
                return NotFound();
            }

            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/
    
            var blog = await blogPostRepository.GetBlogWithIdAsync(id);
            await blogPostRepository.IncrementViewCountAsync(userId, id);

            var response = new BlogDetailsDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Slug = blog.Slug,
                Content = blog.Content,
                Category = blog.Category.Name,
                Date = blog.CreationDate.ToString("dd-MM-yyyy"),
                Images = blog.Images.Select(x => x.Url).ToArray(),
                AuthorId = blog.AuthorId,
                AuthorName = blog.Author.FirstName + " " + blog.Author.LastName,
                AuthorDescription = blog.Author.Description,
                AuthorImageUri = blog.Author.ProfileImage != null ? blog.Author.ProfileImage.Url : "" ,
                Toc = JsonSerializer.Deserialize<List<TocItem>>(blog.TocJson),
                Bookmarks = blog.BookmarkCount
            };

            response.Comments = blog.Comments.Select(x => new CommentDetailsDto()
            {
                Id = x.Id,
                Date = x.CreatedDate.ToString("dd-MM-yyyy"),
                AuthorId = x.UserId,
                AuthorName = x.User.FirstName + " " + x.User.LastName,
                AuthorImageUri = x.User.ProfileImage != null ? x.User.ProfileImage.Url : "",
                Content = x.Content,

                Likes = x.Likes
            }).ToList();

            var tags = await blogPostRepository.GetTagsForBlogAsync(id);
            response.Tags = tags.Select(x => x.Name).ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/delete")]
        public async Task<IActionResult> GetBlogForDelete(int id)
        {
            if(await blogPostRepository.BlogWithIdExistsAsync(id)== false)
            {
                return NotFound();
            }

            var blog = await blogPostRepository.GetBlogWithIdAsync(id);

            var response = new BlogForDeleteDto
            {
                Id = blog.Id,
                Title = blog.Title,
                CommentsCount = blog.Comments.Count(),
                Views = blog.ViewCount,
                Bookmarks = blog.BookmarkCount
            };           

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if(await blogPostRepository.BlogWithIdExistsAsync(id)== false)
            {
                return NotFound();
            }

            await blogPostRepository.DeleteBlogAsync(id);

            return Ok();
        }
    }
}
