using Application.Models.Identity.Dtos;

namespace Application.Contracts.IServices
{
    public interface IUserService
    {
        Task<UserForGettingDto> GetUserAsync(string email);
        Task<List<UserForGettingDto>> GetAllUsersAsync();
        Task UpdateUserAsync(string userId, UserForUpdatingDto userForUpdatingDto);
        Task<bool> BanUserAsync(string userId);
        Task<bool> UnbanUserAsync(string userId);
    }
}
