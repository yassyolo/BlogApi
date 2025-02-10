using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AchievementController : Controller
    {
        private readonly IAchievementRepository achievementRepository;
        private readonly IBlogPostRepository blogRepository;

        public AchievementController(IAchievementRepository achievementRepository, IBlogPostRepository bloRepository)
        {
            this.achievementRepository = achievementRepository;
            this.blogRepository = bloRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/
            var achievements = await achievementRepository.GetAllForUserAsync(userId);

            var response = achievements.Select(x => new AchievementDto()
            {
                Id = x.Achievement.Id,
                Name = x.Achievement.Name,
                Description = x.Achievement.Description,
                ImageUri = x.Achievement.Images.Url == "" ? "" : x.Achievement.Images.Url,
                ConditionType = x.Achievement.ConditionType,
                ConditionValue = x.Achievement.ConditionValue,
                Progress = x.Progress
            }).ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("my-ranking")]
        public async Task<IActionResult> GetMyRank()
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                       {
             *                                      return NotFound();
             *                                                 }*/
            var rank = await achievementRepository.GetRankAsync(userId);

            var response = new MyRankingDto()
            {
                MyRank = rank.Rank,
                MyPoints = rank.Points,
                TotalUsers = rank.TotalUsers
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("top-users")]
        public async Task<IActionResult> GetTopUsers()
        {
            var topUsers = await achievementRepository.GetTopUsersAsync();

            var response = topUsers.Select(x => new TopUserPointsDto()
            {
                Id = x.Id,
                ImageUri = x.ProfileImage == null ? "" : x.ProfileImage.Url,
                UserName = x.UserName,
                Points = x.Points
            }).ToList();
            
            return Ok(response);
        }

        [HttpGet]
        [Route("top-blogs")]
        public async Task<IActionResult> GetTopBlogs([FromQuery] string? from = "lastDay")
        {
            var topBlogs = await blogRepository.GetTopRankingBlogsAsync(from);

            var response = topBlogs.Select(x => new TopRankingBlogsDto()
            {
                Id = x.Id,
                Title = x.Title,
                Date = x.CreationDate.ToString("dd-MM-yyyy"),
                ImageUri = x.Images != null ? x.Images.Select(x => x.Url).First() : "",
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                AuthorId = x.Author.Id,
                AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                CommentsCount = x.Comments.Count(),
                ReadingsCount = x.ViewCount,
                BookmarksCount = x.BookmarkCount
            }).ToList();

            return Ok(response);
        }
    }
}
