using System.Security.Claims;

namespace FreshVegCart.Shared.Extensions
{
    public static class IdentityExtension
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
