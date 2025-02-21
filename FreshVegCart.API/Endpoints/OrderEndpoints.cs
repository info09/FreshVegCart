using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.Extensions;
using FreshVegCart.Shared.SeedWorks;
using System.Security.Claims;

namespace FreshVegCart.API.Endpoints
{
    public static class OrderEndpoints
    {
        public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var orderGroup = endpoints.MapGroup("/api/orders").RequireAuthorization().WithTags("Orders");
            endpoints.MapPost("/place-order", async (IOrderService orderService, PlaceOrderDto dto, ClaimsPrincipal claimsPrincipal) =>
            {
                var result = await orderService.PlaceOrderAsync(dto, claimsPrincipal.GetUserId());
                return Results.Ok(result);
            })
            .Produces<ApiResult>()
            .WithName("PlaceOrder");

            endpoints.MapGet("/users/{userId}", async (IOrderService orderService, int userId, int startIndex, int pageSize, ClaimsPrincipal claimsPrincipal) =>
            {
                if(userId != claimsPrincipal.GetUserId())
                    return Results.Unauthorized();
                
                var orders = await orderService.GetUserOrdersAsync(userId, startIndex, pageSize);
                return Results.Ok(orders);
            }).Produces<ApiResult<OrderDto[]>>().WithName("GetUserOrders");

            endpoints.MapGet("/users/{userId}/orders/{orderId}", async (IOrderService orderService, int userId, int orderId, ClaimsPrincipal claimsPrincipal) =>
            {
                if (userId != claimsPrincipal.GetUserId())
                    return Results.Unauthorized();

                var orders = await orderService.GetUserOrderItemsAsync(orderId, userId);
                return Results.Ok(orders);
            }).Produces<ApiResult<OrderDto[]>>().WithName("GetUserOrderItems");

            return endpoints;
        }
    }
}
