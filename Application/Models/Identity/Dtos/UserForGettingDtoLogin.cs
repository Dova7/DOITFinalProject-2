namespace Application.Models.Identity.Dtos
{
    public class UserForGettingDtoLogin
    {
        public string Id { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
