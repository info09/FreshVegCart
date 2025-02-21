using Microsoft.AspNetCore.Identity;
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

        public static User[] GetSeedData()
        {
            // Password: Admin@123$
            User[] userAdmin = [
            new () { Id = 1, Name = "Admin", Email = $"huytq@ics-p.vn", PasswordHash = "AQAAAAIAAYagAAAAEILS9TM+EK5VrNfit/ylRBluPlqUZf0ZbxOajnXTLKNv+Bo2UPJyKpDkmtL0I5kqBg==", Mobile = "0328478290" },
            ];

            return userAdmin;
        }
    }
}
