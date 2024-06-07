using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.IRepositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> RoleExistsAsync(string role);
        string AuthenticatedUserId();
        string AuthenticatedUserRole();
    }
}
