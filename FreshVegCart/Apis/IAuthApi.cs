using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Refit;

namespace FreshVegCart.Apis
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto request);
        [Post("/api/auth/register")]
        Task<ApiResult> RegisterAsync(RegisterDto request);
    }
}
