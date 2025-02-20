using FreshVegCart.Shared.SeedWorks;

namespace FreshVegCart.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ApiResult> PlaceOrderAsync();
        Task GetUserOrdersAsync (int userId, int pageIndex, int pageSize);
        Task GetUserOrderItemsAsync(int orderId, int userId);
    }
}
