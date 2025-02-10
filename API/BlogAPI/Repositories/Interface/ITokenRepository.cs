using BlogAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace BlogAPI.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(ApplicationUser user, List<string> roles);
        Task CreateUserAchievements(string id);
        Task<bool> UserWithUserIdExistsAsync(string userId);
    }
}
