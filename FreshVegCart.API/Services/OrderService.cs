using FreshVegCart.API.Data;
using FreshVegCart.API.Data.Entities;
using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<OrderItemDto[]>> GetUserOrderItemsAsync(int orderId, int userId)
        {
            var order = await _context.Orders.AsNoTracking().Include(i => i.OrderItems).FirstOrDefaultAsync(i => i.Id == orderId);
            if (order == null) return ApiResult<OrderItemDto[]>.Failure("Order not found");

            if (order.UserId != userId) return ApiResult<OrderItemDto[]>.Failure("You are not authorized to view this order");

            return ApiResult<OrderItemDto[]>
                .Success(
                order.OrderItems.Select(i => new OrderItemDto
                {
                    Id = i.Id,
                    ProductImageUrl = i.ImageUrl,
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    ProductPrice = i.ProductPrice,
                    Unit = i.Unit
                }).ToArray());
        }

        public async Task<ApiResult<AddressDto[]>> GetUserOrdersAsync(int userId, int pageIndex, int pageSize)
        {
            var addresses = await _context.UserAddresses
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(i => i.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(i => new AddressDto
                {
                    Id = i.Id,
                    Address = i.Address,
                    Name = i.Name,
                    IsDefault = i.IsDefault
                })
                .ToArrayAsync();

            return ApiResult<AddressDto[]>.Success(addresses);
        }

        public async Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, int userId)
        {
            if (dto.Items.Length == 0) return ApiResult.Failure("No items in the order");

            var productIds = dto.Items.Select(x => x.ProductId).ToHashSet();
            var products = await _context.Products.Where(x => productIds.Contains(x.Id)).ToDictionaryAsync(i => i.Id);

            if (products.Count == dto.Items.Length)
            {
                return ApiResult.Failure("Some products are not valid");
            }

            var orderItem = dto.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ImageUrl = products[x.ProductId].ImageUrl,
                ProductName = products[x.ProductId].Name,
                ProductPrice = products[x.ProductId].Price,
                Unit = products[x.ProductId].Unit
            }).ToArray();

            var now = DateTime.UtcNow;
            var order = new Order
            {
                UserId = userId,
                Address = dto.Address,
                AddressName = dto.AddressName,
                TotalItems = dto.Items.Length,
                TotalAmount = orderItem.Sum(x => x.ProductPrice * x.Quantity),
                Date = now,
                OrderItems = orderItem,

            };

            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return ApiResult.Success();
            }
            catch (Exception ex)
            {
                return ApiResult.Failure(ex.Message);
            }
        }
    }
}
