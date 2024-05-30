using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.IRepositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetUserAsync(string userName);
        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        Task<IEnumerable<string>> GetRolesAsync(IdentityUser user);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task AddToRoleAsync(IdentityUser user, string role);
        Task<bool> RoleExistsAsync(string role);
    }
}
