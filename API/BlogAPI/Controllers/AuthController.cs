using BlogAPI.Models.Domain;
using BlogAPI.Models.DTO;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim()
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                result = await userManager.AddToRoleAsync(user, "User");
                await tokenRepository.CreateUserAchievements(user.Id);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (result.Errors.Any())
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }

                }
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = await userManager.FindByEmailAsync(request.Email);

            if(user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);

                var roles = await userManager.GetRolesAsync(user);
                if (passwordCheck)
                {
                    var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());
                    var response = new LoginResponseDto()
                    {
                        Email = user.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
            }

            ModelState.AddModelError("", "Invalid email or password");

            return ValidationProblem(ModelState);
        }
    }
}
