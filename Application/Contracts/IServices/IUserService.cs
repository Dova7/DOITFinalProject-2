using Application.Models.Identity.Dtos;
using Application.Models.Main.Dtos.Topic;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts.IServices
{
    public interface IUserService
    {
        Task<UserForGettingDto> GetUserAsync(string email);
        Task<List<UserForGettingDto>> GetAllUsersAsync();
        Task UpdateUserAsync(Guid id, JsonPatchDocument<UserForUpdatingDto> patchDocument);
    }
}
