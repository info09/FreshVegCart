using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Refit;

namespace FreshVegCart.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {
        [Post("/api/users/address")]
        Task<ApiResult> SaveAddressAsync(AddressDto dto);

        [Get("/api/users/addresses")]
        Task<ApiResult<AddressDto[]>> GetAddressesAsync();

        [Post("/api/users/change-password")]
        Task<ApiResult> ChangePasswordAsync(ChangePasswordDto dto);
    }
}
