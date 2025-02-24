using FreshVegCart.Shared.Dto;

namespace FreshVegCart.Services
{
    public class CartService
    {
        public List<ProductDto> Items { get; set; }

        public int Count { get; set; }

        public string DisplayCount => Count < 100 ? $"{Count}" : "99+";

        public event Action? CartCountChanged;

        public void IncreaseQuantity(ProductDto item)
        {
            Count++;
            CartCountChanged?.Invoke();
        }

        public void DecreaseQuantity(ProductDto item)
        {
            Count--;
            CartCountChanged?.Invoke();
        }
    }
}
