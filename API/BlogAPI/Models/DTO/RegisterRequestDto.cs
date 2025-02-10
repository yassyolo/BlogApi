using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models.DTO
{
    public class RegisterRequestDto
    {
        [StringLength(50, MinimumLength = 0)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
