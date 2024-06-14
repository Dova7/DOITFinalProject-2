using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity.Dtos
{
    public class UserForUpdatingDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Display name must be between 3 and 50 characters.")]
        public string DisplayName { get; set; } = null!;
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must be numeric.")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, and one digit.")]
        public string Password { get; set; } = null!;
        [Required]
        public string CurrentPassword { get; set; } = null!;
    }
}
