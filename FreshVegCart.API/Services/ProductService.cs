using FreshVegCart.API.Data;
using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ProductDto[]> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().Select(i => new ProductDto()
            {
                Id = i.Id,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                Price = i.Price,
                Unit = i.Unit
            }).ToArrayAsync();
        }
    }
}
