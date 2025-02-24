using FreshVegCart.Shared.Dto;

namespace FreshVegCart.Data
{
    public class CartModel
    {
        public int CartItemId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        public decimal Amount => Quantity * Price;

        public static CartModel FromDto(ProductDto dto)
        {
            return new CartModel
            {
                ProductId = dto.Id,
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Unit = dto.Unit,
                Quantity = dto.Quantity
            };
        }
    }
}
