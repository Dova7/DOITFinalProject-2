namespace Application.Models.Identity.Dtos
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
