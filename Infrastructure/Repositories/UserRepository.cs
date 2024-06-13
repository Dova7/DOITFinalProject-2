using Application.Contracts.IRepositories;
using Application.Service.Exceptions;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser> GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException("Unable to find user");
            }            
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddToRoleAsync(ApplicationUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
            
        }

        public async Task<bool> RoleExistsAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }
        public string AuthenticatedUserId()
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (result == null)
                {
                    throw new ArgumentNullException(nameof(result));
                }
                return result;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }

        public string AuthenticatedUserRole()
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
                if (result == null)
                {
                    throw new ArgumentNullException(nameof(result));
                }
                return result;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException("Unable to find user");
            }
        }

        public async Task BanUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);

        }

        public async Task UnbanUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            await _userManager.SetLockoutEndDateAsync(user, null);
        }

        public async Task<List<ApplicationUser>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<ApplicationUser> query = _userManager.Users;

            if (includeProperties != null)
            {
                var properties = includeProperties.Split(',');

                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }

            var users = await query.ToListAsync();
            if (!users.Any())
            {
                throw new UserNotFoundException();
            }
            return users;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email, string? includeProperties = null)
        {
            var userQuery = _userManager.Users;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in properties)
                {
                    userQuery = userQuery.Include(property);
                }
            }

            var user = await userQuery.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException("Unable to find user");
            }
        }


        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            var userFromDb = await _userManager.FindByIdAsync(user.Id);
            if (userFromDb != null)
            {
                userFromDb.Email = user.Email;
                userFromDb.DisplayName = user.DisplayName;
                userFromDb.PhoneNumber = user.PhoneNumber;

                if (userFromDb.PasswordHash == null)
                {
                    throw new Exception("No password hash found for the user");
                }
                var passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(userFromDb, userFromDb.PasswordHash, currentPassword);
                if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    throw new Exception("Current password is incorrect");
                }
                userFromDb.PasswordHash = _userManager.PasswordHasher.HashPassword(userFromDb, newPassword);
            }
            else
            {
                throw new UserNotFoundException();
            }

            await _userManager.UpdateAsync(userFromDb);
            return userFromDb;
        }

        public async Task DeleteUserAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            await _userManager.DeleteAsync(user);
        }
    }
}
