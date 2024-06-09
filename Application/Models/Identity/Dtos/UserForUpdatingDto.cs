using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity.Dtos
{
    public class UserForUpdatingDto
    {
        public string Email { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;
        [Required]
        public string CurrentPassword { get; set; } = null!;
    }
}
