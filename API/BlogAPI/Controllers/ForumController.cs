using BlogAPI.Models.DTO.Forum;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ForumController : Controller
    {
        private readonly IForumRepository forumRepository;

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await forumRepository.GetAllCategoriesAsync();

            var response = categories.Select(x => new ForumCategoryDto()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("communities/last-visited")]
        public async Task<IActionResult> GetLastVisitedCommunities()
        {
            var communities = await forumRepository.GetLastVisitedCommunitiesAsync();

            var response = communities.Select(x => new LastVisitedForumCommunityDto()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUri = x.Image != null ? x.Image.Url : ""
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("communities/most-popular")]
        public async Task<IActionResult> GetMostPopularCommunities()
        {
            var communities = await forumRepository.GetMostPopularCommunitiesAsync();

            var response = communities.Select(x => new MostPopularCommunitiesDto()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUri = x.Image != null ? x.Image.Url : "",
                Members = x.UserForumCommunities.Count()
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("communities/feed")]
        public async Task<IActionResult> GetCommunitiesForFeed()
        {
            var communities = await forumRepository.GetCommunitiesForFeedAsync();

            var response = communities.Select(x => {
                var postWithImage = x.ForumPosts.FirstOrDefault(p => p.Image != null);

                return new ForumCommunitiesForFeedDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUri = x.Image?.Url ?? "",
                    PostTitle = postWithImage?.Title ?? "No Title",
                    PostContent = postWithImage?.Content ?? "No Content",
                    PostImageUri = postWithImage?.Image?.Url ?? "",
                };
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("feed")]
        public async Task<IActionResult> GetFeed([FromQuery] string? sorting, [FromQuery] int? forumId, [FromQuery] int? categoryId)
        {
            var feed = await forumRepository.GetFeedAsync(sorting, forumId, categoryId);

            var response = feed.Select(x => new ForumPostsForFeedDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Date = x.CreatedAt.ToString("dd-MM-yyyy"),
                ImageUri = x.Image != null ? x.Image.Url : "",
                CommentsCount = x.Comments.Count(),
                Votes = x.Votes,
                CommunityName = x.ForumCommunity.Name,
                CommunityImageUri = x.ForumCommunity.Image != null ? x.ForumCommunity.Image.Url : "",
                AuthorName = x.User.FirstName + " " + x.User.LastName,
                AuthorImageUri = x.User.ProfileImage != null ? x.User.ProfileImage.Url : "",
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        [Route("community/{id}/join")]
        public async Task<IActionResult> JoinCommunity(int id)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            if(await forumRepository.CommunityWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            await forumRepository.JoinCommunityAsync(userId, id);

            return Ok();
        }

        [HttpPost]
        [Route("community/{id}/leave")]
        public async Task<IActionResult> LeaveCommunity(int id)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                       {
             *                                      return NotFound();
             *                                                 }*/

            if(await forumRepository.CommunityWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.UserIsMemberOfCommunityAsync(userId, id) == false)
            {
                return BadRequest();
            }

            await forumRepository.LeaveCommunityAsync(userId, id);

            return Ok();
        }

        [HttpPost]
        [Route("community/{id}/post")]
        public async Task<IActionResult> CreatePost(int id, [FromBody] CreateForumPostDto post)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             {
             return NotFound();
                                                            }*/

            if(await forumRepository.CommunityWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.UserIsMemberOfCommunityAsync(userId, id) == false)
            {
                return BadRequest();
            }

            await forumRepository.CreatePostAsync(userId, id, post);

            return Ok();
        }

        [HttpDelete]
        [Route("community/{id}/post/{postId}")]
        public async Task<IActionResult> DeletePost(int id, int postId)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         {
             *                                     return NotFound();
             *                                                                                                }*/

            if(await forumRepository.CommunityWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.UserIsMemberOfCommunityAsync(userId, id) == false)
            {
                return BadRequest();
            }

            if(await forumRepository.PostExistsAsync(postId) == false)
            {
                return NotFound();
            }

            if(await forumRepository.UserIsAuthorOfPostAsync(userId, postId) == false)
            {
                return BadRequest();
            }

            await forumRepository.DeletePostAsync(postId);

            return Ok();
        }

        [HttpGet]
        [Route("community/{id}")]
        public async Task<IActionResult> GetCommunity(int id)
        {
            if(await forumRepository.CommunityWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            var community = await forumRepository.GetCommunityAsync(id);

            var response = new ForumCommunityDto()
            {
                Id = community.Id,
                Name = community.Name,
                Description = community.Description,
                ImageUri = community.Image != null ? community.Image.Url : "",
                Members = community.UserForumCommunities.Count(),
                Category = community.ForumCategory.Name,
                CategoryId = community.ForumCategory.Id,
                CreationDate = community.Joined.ToString("dd-MM-yyyy"),
                PostsCount = community.ForumPosts.Count(),
                Rules = JsonSerializer.Deserialize<List<string>>(community.RulesJson),  
            };

            response.Rank = await forumRepository.GetCommunityRankAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if(await forumRepository.ForumCategoryWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            var category = await forumRepository.GetForumCategoryAsync(id);

            var response = new ForumCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                MemberCount = category.ForumCommunities.SelectMany(x => x.UserForumCommunities).Count(),
                PostsCount = category.ForumCommunities.SelectMany(x => x.ForumPosts).Count()
            };

            return Ok(response);
        }
    }
}
