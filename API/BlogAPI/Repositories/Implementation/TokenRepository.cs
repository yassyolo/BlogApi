using BlogAPI.Data;
using BlogAPI.Models.Domain;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogAPI.Repositories.Implementation
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public TokenRepository(IConfiguration configuration, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.context = context;
        }

        public string CreateJwtToken(ApplicationUser user, List<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(400),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task CreateUserAchievements(string id)
        {
            await context.Achievements.ToListAsync();
            foreach (var achievement in context.Achievements)
            {
                var userAchievement = new UserAchievement
                {
                    UserId = id,
                    AchievementId = achievement.Id,
                    IsAchieved = false
                };
                await context.UserAchievements.AddAsync(userAchievement);
            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> UserWithUserIdExistsAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId) != null;
        }
    }
}
