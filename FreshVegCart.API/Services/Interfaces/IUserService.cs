using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;

namespace FreshVegCart.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult> SaveAddressAsync(AddressDto dto, int userId);
        Task<ApiResult<AddressDto[]>> GetAddressesAsync(int userId);
    }
}
