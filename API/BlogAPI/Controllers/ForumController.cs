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
        [Route("post/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         {
             *                                     return NotFound();
             *                                                                                                }*/

            if(await forumRepository.PostExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.UserIsAuthorOfPostAsync(userId, id) == false)
            {
                return BadRequest();
            }

            await forumRepository.DeletePostAsync(id);

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

        [HttpGet]
        [Route("category/{id}/communities")]
        public async Task<IActionResult> GetCommunitiesInCategory(int id)
        {
            if(await forumRepository.ForumCategoryWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }

            var communities = await forumRepository.GetCommunitiesInCategoryAsync(id);

            var response = communities.Select(x => new MostPopularCommunitiesDto()
            {
                Id = x.Id,
                Name = x.Name,               
                ImageUri = x.Image != null ? x.Image.Url : "",
                Members = x.UserForumCommunities.Count(),
               
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("posts/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            if(await forumRepository.PostExistsAsync(id) == false)
            {
                return NotFound();
            }

            var post = await forumRepository.GetPostAsync(id);

            var response = new ForumPostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Date = post.CreatedAt.ToString("dd-MM-yyyy"),
                ImageUri = post.Image != null ? post.Image.Url : "",
                CommentsCount = post.Comments.Count(),
                Votes = post.Votes,
                CommunityName = post.ForumCommunity.Name,
                CommunityId = post.ForumCommunity.Id,
                CommunityImageUri = post.ForumCommunity.Image != null ? post.ForumCommunity.Image.Url : "",
                AuthorName = post.User.FirstName + " " + post.User.LastName,
                AuthorImageUri = post.User.ProfileImage != null ? post.User.ProfileImage.Url : "",
                Comments = post.Comments.Select(x => new ForumCommentDto()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                    AuthorName = x.User.FirstName + " " + x.User.LastName,
                    AuthorId = x.User.Id,
                    AuthorImageUrl = x.User.ProfileImage != null ? x.User.ProfileImage.Url : "",
                    Votes = x.Votes
                }).ToArray()
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("post/{id}/comments/{commentId}/upvote")]
        public async Task<IActionResult> VoteComment(int id, int commentId)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                       {
             *                                     *                                      return NotFound();
             *                                                 *                                                 }*/

            if(await forumRepository.PostExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.CommentExistsAsync(commentId) == false)
            {
                return NotFound();
            }

            /*if(await forumRepository.UserHasVotedOnCommentAsync(userId, commentId) == true)
            {
                return BadRequest();
            }*/

            await forumRepository.VoteCommentAsync(userId, commentId);

            return Ok();
        }

        [HttpPost]
        [Route("post/{id}/comments/{commentId}/downvote")]
        public async Task<IActionResult> DownVoteComment(int id, int commentId)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                         *                       {
             *                                     *                                     *                                      return NotFound();
             *                                                 *                                                 *                                                 }*/

            if(await forumRepository.PostExistsAsync(id) == false)
            {
                return NotFound();
            }

            if(await forumRepository.CommentExistsAsync(commentId) == false)
            {
                return NotFound();
            }

            /*if(await forumRepository.UserHasVotedOnCommentAsync(userId, commentId) == true)
             *            {
             *                           return BadRequest();
             *                                      }*/

            await forumRepository.DownVoteCommentAsync(userId, commentId);

            return Ok();
        }

        [HttpPost]
        [Route("post/{id}/comments")]
        public async Task<IActionResult> CreateComment(int id, [FromBody]string comment)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *             *             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                         *                         *                         *                       {
             *                                     *                                     *                                     *                                     *                                      return NotFound();
             *                                                 *                                                 *                                                 *                                                 *                                                 }*/

            if(await forumRepository.PostExistsAsync(id) == false)
            {
                return NotFound();
            }

            var newComment = await forumRepository.CreateCommentAsync(userId, id, comment);
            var response = new ForumCommentDto()
            {
                Id = newComment.Id,
                Content = newComment.Content,
                CreatedAt = newComment.CreatedAt.ToString("dd-MM-yyyy"),
                AuthorId = newComment.UserId,
                AuthorName = newComment.User.FirstName + " " + newComment.User.LastName,
                AuthorImageUrl = newComment.User.ProfileImage != null ? newComment.User.ProfileImage.Url : "",
                Votes = newComment.Votes
            };
    
            return Ok(response);
        }
    }
}
