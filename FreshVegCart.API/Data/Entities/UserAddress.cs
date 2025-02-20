using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.API.Data.Entities
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required, MaxLength(250)]
        public string Address { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }
    }
}
