using FreshVegCart.API.Data;
using FreshVegCart.API.Services.Interfaces;

namespace FreshVegCart.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
