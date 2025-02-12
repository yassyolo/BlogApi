using BlogAPI.Extensions;
using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("blogs/{blogId}/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository commentRepository;
        private readonly ITokenRepository tokenRepository;

        public CommentController(ICommentRepository commentRepository, ITokenRepository tokenRepository)
        {
            this.commentRepository = commentRepository;
            this.tokenRepository = tokenRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int blogId)
        {
            var comments = await commentRepository.GetAllAsync(blogId);

            var response = comments.Select(x => new CommentDetailsDto()
            {
                Id = x.Id,
                Date = x.CreatedDate.ToString("dd-MM-yyyy"),
                AuthorId = x.UserId,
                AuthorName = x.User.FirstName + " " + x.User.LastName,
                Content = x.Content,
                Likes = x.Likes
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int blogId, [FromBody] string comment)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var userId = "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c";
            /*var userId = User.GetUserId();

            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

             var newComment = await commentRepository.CreateAsync(userId, blogId, comment);
            var response = new CommentDetailsDto()
            {
                Id = newComment.Id,
                Date = newComment.CreatedDate.ToString("dd-MM-yyyy"),
                AuthorId = newComment.UserId,
                AuthorName = newComment.User.FirstName + " " + newComment.User.LastName,
                AuthorImageUri = newComment.User.ProfileImage?.Url ?? string.Empty,
                Content = newComment.Content,
                Likes = newComment.Likes
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{commentId}/like")]
        public async Task<IActionResult> Like(int blogId, int commentId)
        {
            //Todo: Check if user is authenticated
            var userId = "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c";
            /*var userId = User.GetUserId();

            if (await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            if (await commentRepository.CommentExistsAsync(blogId, commentId) == false)
            {
                return NotFound();
            }

            /*if(await commentRepository.UserLikedCommentAsync(commentId, userId) == true)
            {
                return BadRequest();
            }*/

            await commentRepository.LikeAsync(commentId);

            return Ok();
        }
    }
}
