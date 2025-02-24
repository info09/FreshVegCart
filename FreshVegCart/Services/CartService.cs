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

        public void RemoveCartItem(CartModel cartItem)
        {
            Items.Remove(cartItem);
            NotifyCountChanged();
        }

        public async Task ClearCartItemAsync()
        {
            if (await App.Current.Windows[0].Page.DisplayAlert("Confirm?", "Are you sure, you want to clear the cart?", "Yes", "No"))
            {
                Items.Clear();
                NotifyCountChanged();
            }
        }

        private void NotifyCountChanged()
        {
            Count = Items.Sum(i => i.Quantity);
            CartCountChanged?.Invoke();
        }
    }
}
