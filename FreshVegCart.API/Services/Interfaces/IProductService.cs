using FreshVegCart.Shared.Dto;

namespace FreshVegCart.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto[]> GetProductsAsync();
    }
}
