using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dto
{
    public interface LoginDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
