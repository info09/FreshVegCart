using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Refit;

namespace FreshVegCart.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IOrderApi
    {
        [Post("/api/orders/place-order")]
        Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, int userId);

        [Get("/api/orders/users/{userId}")]
        Task<ApiResult<OrderDto[]>> GetUserOrdersAsync(int userId, int startIndex, int pageSize);

        [Get("/api/orders/users/{userId}/orders/{orderId}/items")]
        Task<ApiResult<OrderItemDto[]>> GetUserOrderItemsAsync(int orderId, int userId);
    }
}
