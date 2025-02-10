using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.DTO
{
    public class LoginRequestDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
