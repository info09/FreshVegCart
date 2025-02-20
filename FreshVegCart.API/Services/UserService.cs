using FreshVegCart.API.Data;
using FreshVegCart.API.Data.Entities;
using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<AddressDto[]>> GetAddressesAsync(int userId) 
            => ApiResult<AddressDto[]>.Success(
                await _context.UserAddresses.AsNoTracking()
                    .Where(i => i.UserId == userId)
                    .Select(i => new AddressDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Address = i.Address,
                        IsDefault = i.IsDefault
                    }).ToArrayAsync());

        public async Task<ApiResult> SaveAddressAsync(AddressDto dto, int userId)
        {
            UserAddress? address = null;
            if (dto.Id == 0)
            {
                address = new UserAddress()
                {
                    Address = dto.Address,
                    Id = dto.Id,
                    IsDefault = dto.IsDefault,
                    UserId = userId,
                    Name = dto.Name,
                };
                await _context.UserAddresses.AddAsync(address);
            }
            else
            {
                address = await _context.UserAddresses.FindAsync(dto.Id);
                if (address is null)
                    return ApiResult.Failure("Address not found");

                address.Name = dto.Name;
                address.Address = dto.Address;
                address.UserId = userId;
                address.IsDefault = dto.IsDefault;
                address.UserId = userId;

                _context.UserAddresses.Update(address);
            }

            try
            {
                if (dto.IsDefault)
                {
                    var defaultAddress = await _context.UserAddresses.FirstOrDefaultAsync(i => i.UserId == userId && i.IsDefault && i.Id != dto.Id);
                    if (defaultAddress is not null)
                    {
                        defaultAddress.IsDefault = false;
                    }
                }
                
                await _context.SaveChangesAsync();
                return ApiResult.Success();
            }
            catch (Exception ex)
            {
                return ApiResult.Failure(ex.Message);
                throw;
            }
        }
    }
}
