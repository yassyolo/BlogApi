using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogAPI.Models.DTO
{
    public class CreateBlogPostRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public List<int> TagIds { get; set; } = new();

        public List<string> NewTags { get; set; } = new();

        public List<IFormFile> Images { get; set; } = new();

        [FromForm(Name = "toc")]
        public string Toc { get; set; } = string.Empty;

        public List<TocItem> GetTocList()
        {
            return JsonSerializer.Deserialize<List<TocItem>>(Toc);
        }
    }
}
