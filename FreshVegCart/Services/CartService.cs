using FreshVegCart.Data;
using FreshVegCart.Shared.Dto;

namespace FreshVegCart.Services
{
    public class CartService
    {
        public List<CartModel> Items { get; set; } = [];

        public int Count { get; set; }

        public string DisplayCount => Count < 100 ? $"{Count}" : "99+";

        public event Action? CartCountChanged;

        public decimal TotalAmount => Items.Sum(i => i.Amount);

        public void IncreaseQuantity(ProductDto product)
        {
            var cartItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (cartItem is null)
            {
                cartItem = CartModel.FromDto(product);
                Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = product.Quantity;
            }

            NotifyCountChanged();
        }

        public void DecreaseQuantity(ProductDto product)
        {
            var cartItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (cartItem is null)
            {
                return;
            }
            else
            {
                cartItem.Quantity = product.Quantity;
                if (cartItem.Quantity == 0)
                    Items.Remove(cartItem);
            }
            NotifyCountChanged();
        }

        public void IncreaseCartItemQuantity(CartModel cartItem)
        {
            cartItem.Quantity++;
            NotifyCountChanged();
        }

        public void DecreaseCartItemQuantity(CartModel cartItem)
        {
            cartItem.Quantity--;
            if (cartItem.Quantity == 0)
                Items.Remove(cartItem);
            NotifyCountChanged();
        }

        public async Task RemoveCartItem(CartModel cartItem)
        {
            Items.Remove(cartItem);
            NotifyCountChanged();
            await MauiInterop.ToastAsync("Item removed from cart");
        }

        public async Task ClearCartItemAsync()
        {
            if (Items.Count == 0)
                return;

            if (await MauiInterop.ConfirmAsync("Confirm?", "Are you sure, you want to clear the cart?"))
            {
                Items.Clear();
                NotifyCountChanged();
                await MauiInterop.ToastAsync("Cart cleared successfully");
            }
        }

        private void NotifyCountChanged()
        {
            Count = Items.Sum(i => i.Quantity);
            CartCountChanged?.Invoke();
        }
    }
}
