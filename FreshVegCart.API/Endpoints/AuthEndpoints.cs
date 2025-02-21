using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;

namespace FreshVegCart.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var authGroup = endpoints.MapGroup("/api/auth").WithTags("Auth");

            authGroup.MapPost("/register", async (IAuthService authService, RegisterDto dto) =>
            {
                var result = await authService.RegisterUser(dto);
                return Results.Ok(result);
            })
                .Produces<ApiResult>()
                .WithName("Register");

            authGroup.MapPost("/login", async (IAuthService authService, LoginDto dto) =>
            {
                var result = await authService.LoginAsync(dto);
                return Results.Ok(result);
            })
                .Produces<ApiResult<LoggedInUser>>()
                .WithName("Login");
            return endpoints;
        }
    }
}
