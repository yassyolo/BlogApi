using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models.DTO.Stream
{
    public class CreateStreamDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; } = null!;
        public int MaxViewers { get; set; }
        public DateTime When { get; set; }
    }
}
