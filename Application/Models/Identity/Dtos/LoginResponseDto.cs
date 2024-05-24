namespace Application.Models.Identity.Dtos
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
