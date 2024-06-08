using Application.Contracts.IServices;
using Application.Models.Identity.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Service.Implimentations.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            
        }
        public Task<List<UserForGettingDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserForGettingDto> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(Guid id, JsonPatchDocument<UserForUpdatingDto> patchDocument)
        {
            throw new NotImplementedException();
        }
    }
}
