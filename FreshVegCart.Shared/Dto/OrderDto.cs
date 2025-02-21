using FreshVegCart.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        [MaxLength(200)]
        public string? Remarks { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; }

        public int UserAddressId { get; set; }

        public string Address { get; set; }
        public string AddressName { get; set; }
        public int TotalItems { get; set; }

    }
}
