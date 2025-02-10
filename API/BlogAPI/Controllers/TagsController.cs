using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await tagRepository.GetAllAsync();

            var response = tags.Select(x => new TagDto()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(response);
        }
    }
}
