using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity.Dtos
{
    public class UserForUpdatingDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string DisplayName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
