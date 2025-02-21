using FreshVegCart.Shared.Dto;
using Refit;

namespace FreshVegCart.Apis
{
    public interface IProductApi
    {
        [Get("/api/products")]
        Task<ProductDto[]> GetProductsAsync();
    }
}
