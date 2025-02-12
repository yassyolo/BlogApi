using BlogAPI.Models.DTO.Stream;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StreamController : Controller
    {
        private readonly IStreamRepository streamRepository;

        public StreamController(IStreamRepository streamRepository)
        {
            this.streamRepository = streamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStreamsAsync([FromQuery] string? query, [FromQuery] int? categoryId)
        {
            var streams = await streamRepository.GetStreamsAsync(query, categoryId);

            var response = streams.Select(async x => new StreamForFeedDto
            {
                Id = x.Id,
                Name = x.Name,
                OwnerName = x.Owner.UserName,
                OwnerId = x.Owner.Id,
                OwnerImageUrl = x.Owner.ProfileImage == null ? "":x.Owner.ProfileImage.Url,
                ImageUri = x.Image == null ? "" : x.Image.Url,
                ViewersCount = await streamRepository.GetJoinedUsersAsync(x.Id),
                ViwersLimit = x.MaxViewers,
                When = x.When.ToString("dd-MM-yyyy"),
                CreatedOn = x.CreatedOn.ToString("dd-MM-yyyy"),
            }).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Route("{id}/join")]
        public async Task<IActionResult> JoinStreamAsync(int id)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
            {
                return NotFound();
            }*/

            if(await streamRepository.UserIsInStreamAsync(userId, id))
            {
                return BadRequest();
            }
            await streamRepository.JoinStreamAsync(userId, id);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/leave")]
        public async Task<IActionResult> LeaveStreamAsync(int id)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                       {
             *                                      return NotFound();
             *                                                 }*/

            if(await streamRepository.UserIsInStreamAsync(userId, id) == false)
            {
                return BadRequest();
            }
            await streamRepository.LeaveStreamAsync(userId, id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStreamAsync(int id)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var stream = await streamRepository.GetStreamAsync(id);
            var response = new StreamDetailsDto()
            {
                Id = stream.Id,
                Name = stream.Name,
                OwnerName = stream.Owner.UserName,
                OwnerId = stream.Owner.Id,
                OwnerImageUrl = stream.Owner.ProfileImage == null ? "" : stream.Owner.ProfileImage.Url,
                ImageUri = stream.Image == null ? "" : stream.Image.Url,
                ViewersCount = await streamRepository.GetJoinedUsersAsync(stream.Id),
                ViwersLimit = stream.MaxViewers,
                When = stream.When.ToString("dd-MM-yyyy"),
                CreatedOn = stream.CreatedOn.ToString("dd-MM-yyyy"),
                CategoryName = stream.Category.Name,
                CategoryId = stream.CategoryId,
                Description = stream.Description,
                OwnerDescription = stream.Owner.Description
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStreamAsync([FromBody] CreateStreamDto createStreamDto)
        {
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                       {
             *                                      return NotFound();
             *                                                 }*/

            await streamRepository.CreateStreamAsync(createStreamDto, userId);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/edit")]
        public async Task<IActionResult> GetStreamForEditAsync(int id)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                       {
             *                                     *                                      return NotFound();
             *                                                 *                                                 }*/

            if(await streamRepository.UserIsOwnerOfStreamAsync(userId, id) == false)
            {
                return BadRequest();
            }
            var stream = await streamRepository.GetStreamForEditAsync(id);
            var response = new CreateStreamDto()
            {
                Name = stream.Name,
                Description = stream.Description,
                CategoryId = stream.CategoryId,
                MaxViewers = stream.MaxViewers,
                When = stream.When
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStreamAsync(int id, [FromBody] CreateStreamDto updateStreamDto)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                       {
             *                                     *                                      return NotFound();
             *                                                 *                                                 }*/

            if(await streamRepository.UserIsOwnerOfStreamAsync(userId, id) == false)
            {
                return BadRequest();
            }
            await streamRepository.UpdateStreamAsync(id, updateStreamDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStreamAsync(int id)
        {
            if(await streamRepository.StreamWithIdExistsAsync(id) == false)
            {
                return NotFound();
            }
            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            /*var userId = User.GetUserId();
             *             *             *            if(await tokenRepository.UserWithUserIdExistsAsync(userId) == false)
             *                         *                         *                       {
             *                                     *                                     *                                      return NotFound();
             *                                                 *                                                 *                                                 }*/

            if(await streamRepository.UserIsOwnerOfStreamAsync(userId, id) == false)
            {
                return BadRequest();
            }
            await streamRepository.DeleteStreamAsync(id);
            return Ok();
        }
    }
}
