using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;

namespace FreshVegCart.API.Endpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/products", async (IProductService productService) =>
            {
                var products = await productService.GetProductsAsync();
                return Results.Ok(products);
            }).Produces<ProductDto[]>().WithName("Products");
            return endpoints;
        }
    }
}
