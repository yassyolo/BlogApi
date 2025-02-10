using System.Security.Claims;

namespace BlogAPI.Extensions
{
    public static class SecurityClaimsExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
