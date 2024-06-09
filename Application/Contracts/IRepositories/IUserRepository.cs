using Domain.Entities.Identity;
using ForumProject.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.IRepositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserAsync(string userName);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email, string? includePropeties = null);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<List<ApplicationUser>> GetAllAsync(string? includePropeties = null);
        Task BanUserAsync(string userId);
        Task UnbanUserAsync(string userId);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> RoleExistsAsync(string role);
        string AuthenticatedUserId();
        string AuthenticatedUserRole();
    }
}
