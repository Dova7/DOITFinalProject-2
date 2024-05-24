using Application.Models.Identity.Dtos;

namespace Application.Contracts.IServices
{
    public interface IAuthService
    {
        Task Register(RegistrationRequestDto registrationRequestDto);
        Task RegisterAdmin(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
