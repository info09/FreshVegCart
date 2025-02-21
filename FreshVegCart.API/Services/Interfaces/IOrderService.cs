using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;

namespace FreshVegCart.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, int userId);
        Task<ApiResult<OrderDto[]>> GetUserOrdersAsync(int userId, int startIndex, int pageSize);
        Task<ApiResult<OrderItemDto[]>> GetUserOrderItemsAsync(int orderId, int userId);
    }
}
