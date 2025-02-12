using BlogAPI.Extensions;
using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookmarkController : Controller
    {
        private readonly IBookmarkRepository bookmarkRepository;
        private readonly ITokenRepository tokenRepository;

        public BookmarkController(IBookmarkRepository bookmarkRepository, ITokenRepository tokenRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
            this.tokenRepository = tokenRepository;
        }

        [HttpGet]
        [Route("all-folders-for-adding")]
        public async Task<IActionResult> GetAllBookmarkFoldersForAdding()
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            var bookmarks = await bookmarkRepository.GetAllForUserAsync(userId);

            var response = bookmarks.Select(x => new BookmarkFolderIndexDto()
            {
                Id = x.Id,
                Name = x.Name,
                BookmarkCount = x.Bookmarks.Count, 
                ImageUrl = x.Bookmarks.Where(b => (b.Author != null && b.Author.ProfileImage != null) || (b.Blog != null && b.Blog.Images.Any()))
                .Select(b => b.Author != null ? b.Author.ProfileImage.Url : b.Blog.Images.FirstOrDefault().Url) 
                .FirstOrDefault() ?? string.Empty 
            });

            return Ok(response);
        }

        [HttpPost]
        [Route("add-to-existing-folder")]
        public async Task<IActionResult> AddToExistingFolder([FromBody] AddToFolderRequestDto request)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            var bookmarkFolder = await bookmarkRepository.GetFolderByIdAsync(request.FolderId);
            if(bookmarkFolder == null)
            {
                return NotFound();
            }

            if(bookmarkFolder.UserId != userId)
            {
                return Unauthorized();
            }

            await bookmarkRepository.AddToFolderAsync(bookmarkFolder, request);
            await bookmarkRepository.IncrementUserBookmarkAchievementAsync(userId);

            return Ok();
        }

        [HttpPost]
        [Route("create-new-folder")]
        public async Task<IActionResult> CreateNewFolder([FromBody] CreateFolderDto request)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            await bookmarkRepository.CreateFolderAsync(request, userId);
            await bookmarkRepository.IncrementUserBookmarkAchievementAsync(userId);

            return Ok();
        }

        [HttpPost]
        [Route("all-folders")]
        public async Task<IActionResult> GetAllBookmarkFolders([FromForm] string? query, [FromForm] string? sorting)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            var bookmarks = await bookmarkRepository.GetAllForUserAsync(userId, query, sorting);

            var response = bookmarks.Select(x => new BookmarkFolderIndexDto()
            {
                Id = x.Id,
                Name = x.Name,
                BookmarkCount = x.Bookmarks.Count, 
                CreationDate = x.CreationDate.ToString("dd-MM-yyyy"),
                ImageUrl = x.Bookmarks.Where(b => (b.Author != null && b.Author.ProfileImage != null) || (b.Blog != null && b.Blog.Images.Any()))
                .Select(b => b.Author != null ? b.Author.ProfileImage.Url : b.Blog.Images.FirstOrDefault().Url) 
                .FirstOrDefault() ?? string.Empty 
            });

            return Ok(response);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetBookmarksInFolder(int id, [FromForm] string? query, [FromForm] string? sorting)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            var bookmarkFolder = await bookmarkRepository.GetFolderByIdAsync(id);
            if(bookmarkFolder == null)
            {
                return NotFound();
            }

            /*if(bookmarkFolder.UserId != userId)
            {
                return Unauthorized();
            }*/
            var bookmarkFolderContents = await bookmarkRepository.GetFolderContentsByIdAsync(id, query, sorting);

            var response = bookmarkFolder.Bookmarks.Select(x => new BookmarkDto()
            {
                Id = x.Id,
                CreationDate = x.Folder.CreationDate.ToString("dd-MM-yyyy"),
                Name = x.Folder.Name,

                BlogId = x.Blog != null ? x.Blog.Id : 0,
                BlogContent = x.Blog != null ? x.Blog.Content : string.Empty,
                BlogTitle = x.Blog != null ? x.Blog.Title : string.Empty,
                BlogImageUrl = x.Blog != null ? x.Blog.Images.FirstOrDefault().Url : string.Empty,

                AuthorId = x.Author != null ? x.Author.Id : string.Empty,
                AuthorUsername = x.Author != null ? x.Author.UserName : string.Empty,
                AuthorName = x.Author != null ? $"{x.Author.FirstName} + {x.Author.LastName}" : string.Empty,
                AuthorImageUrl = x.Author != null ? x.Author.ProfileImage.Url : string.Empty,
                AuthorBookmarksCount = x.Author != null ? x.Author.Blogs.Sum(x => x.Bookmarks.Count()) : 0,
                AuthorCommentsCount = x.Author != null ? x.Author.Blogs.Sum(x => x.Comments.Count()): 0,
            });



            return Ok(response);
        }

        [HttpGet]
        [Route("folder/{id}/delete")]
        public async Task<IActionResult> GettBookmarkFolderForDelete(int id)
        {
            if(await bookmarkRepository.BookmarkFolderExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *{
             *  return NotFound();
             *}*/

            /*if(await bookmarkRepository.UserOwnsFolderAsync(userId, id) == false)
            {
                return Unauthorized();
            }*/

            var bookmarkFolder = await bookmarkRepository.GetFolderByIdAsync(id);
            var response = new BookmarkFolderIndexDto()
            {
                Id = bookmarkFolder.Id,
                Name = bookmarkFolder.Name,
                BookmarkCount = bookmarkFolder.Bookmarks.Count,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("folder/{id}")]
        public async Task<IActionResult> DeleteFolder(int id)
        {
            if (await bookmarkRepository.BookmarkFolderExistsAsync(id) == false)
            {
                return NotFound();
            }
            /*var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *{
             *  return NotFound();
             *}

            if (await bookmarkRepository.UserOwnsFolderAsync(userId, id) == false)
            {
                return Unauthorized();
            }*/

            var bookmarkFolder = await bookmarkRepository.GetFolderByIdAsync(id);


            await bookmarkRepository.DeleteFolderAsync(id);

            return Ok();
        }
    }
}
