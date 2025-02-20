using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;

namespace FreshVegCart.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResult> RegisterUser(RegisterDto dto);
        Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto);
    }
}
