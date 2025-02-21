using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FreshVegCart.Shared.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [JsonIgnore]
        [Required, Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
