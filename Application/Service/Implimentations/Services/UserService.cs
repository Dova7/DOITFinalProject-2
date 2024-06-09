using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Identity.Dtos;
using Application.Service.Mapper;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.Service.Implimentations.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _mapper = MappingProfile.InitializeUser();
            _userRepository = userRepository;
        }

        public async Task<bool> BanUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new KeyNotFoundException("Unable to find user");
            }
            var userRole = _userRepository.AuthenticatedUserRole();
            if (userRole != "Admin".Trim())
            {
                throw new UnauthorizedAccessException("Must be an admin to ban user");
            }
            try
            {
                await _userRepository.BanUserAsync(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<UserForGettingDto>> GetAllUsersAsync()
        {
            var raw = await _userRepository.GetAllAsync(includePropeties: "Comments,Topics");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Users not found");
            }
            var users = _mapper.Map<List<UserForGettingDto>>(raw);
            return users;
        }

        public async Task<UserForGettingDto> GetUserAsync(string email)
        {
            var raw = await _userRepository.GetUserByEmailAsync(email,includePropeties: "Comments,Topics");
            if (raw == null)
            {
                throw new KeyNotFoundException("Users not found");
            }
            var user = _mapper.Map<UserForGettingDto>(raw);
            return user;
        }

        public async Task<bool> UnbanUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new KeyNotFoundException("Unable to find user");
            }
            var userRole = _userRepository.AuthenticatedUserRole();
            if (userRole != "Admin".Trim())
            {
                throw new UnauthorizedAccessException("Must be an admin to unban user");
            }
            try
            {
                await _userRepository.UnbanUserAsync(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task UpdateUserAsync(string userId, UserForUpdatingDto userForUpdatingDto)
        {
            if (userForUpdatingDto is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var authenticatedId = _userRepository.AuthenticatedUserId();
            if (authenticatedId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update credentials");
            }
            var userFromDb = await _userRepository.GetUserByIdAsync(userId);
            if (userFromDb is null)
            {
                throw new ArgumentNullException("User does not exist");
            }
            if (userFromDb.Id != userId)
            {
                throw new UnauthorizedAccessException("Can't update another users topic");
            }
            var updatedUser = _mapper.Map<ApplicationUser>(userForUpdatingDto);
            updatedUser.Id = userId;
            await _userRepository.UpdateUserAsync(updatedUser, userForUpdatingDto.CurrentPassword, userForUpdatingDto.Password);
        }
    }
}
