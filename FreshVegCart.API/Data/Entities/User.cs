using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.API.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(50)]
        public string? Mobile { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
