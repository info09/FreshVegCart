using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.Extensions;
using FreshVegCart.Shared.SeedWorks;
using System.Security.Claims;

namespace FreshVegCart.API.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder builder)
        {
            var userGroup = builder.MapGroup("/api/user").RequireAuthorization().WithTags("User");

            userGroup.MapPost("/address", async (IUserService userService, AddressDto dto, ClaimsPrincipal user) =>
            {
                var userId = user.GetUserId();
                return Results.Ok(await userService.SaveAddressAsync(dto, userId));
            }).Produces<ApiResult>().WithName("SaveAddress");

            builder.MapGet("/addresses", async (IUserService userService, ClaimsPrincipal user) =>
            {
                var userId = user.GetUserId();
                return await userService.GetAddressesAsync(userId);
            }).Produces<ApiResult<AddressDto[]>>().WithName("GetAddresses");

            builder.MapPost("/api/user/change-password", async (IUserService userService, ChangePasswordDto dto, ClaimsPrincipal user) =>
            {
                var userId = user.GetUserId();
                return await userService.ChangePasswordAsync(dto, userId);
            }).Produces<ApiResult>().WithName("ChangePassword");


            return builder;
        }
    }
}
