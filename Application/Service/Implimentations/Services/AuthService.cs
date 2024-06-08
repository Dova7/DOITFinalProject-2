using Application.Contracts;
using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Identity.Dtos;
using Application.Service.Exceptions;
using Application.Service.Mapper;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.Service.Implimentations.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        private const string _userRole = "User";
        private const string _adminRole = "Admin";

        public AuthService(IUserRepository userRepository, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtGenerator;
            _mapper = MappingProfile.InitializeUser();
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetUserAsync(loginRequestDto.UserName.ToLower());
            bool isValid = await _userRepository.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                throw new Exception("Invalid username or password");
            }
            
            var roles = await _userRepository.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            var userDto = _mapper.Map<UserForGettingDto>(user);

            LoginResponseDto result = new()
            {
                User = userDto,
                Token = token
            };
            return result;
        }

        public async Task Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(registrationRequestDto);

            try
            {
                var result = await _userRepository.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _userRepository.GetUserAsync(registrationRequestDto.UserName.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _userRepository.RoleExistsAsync(_userRole))
                        {
                            await _userRepository.AddToRoleAsync(userToReturn, _userRole);
                        }

                        var userDto = _mapper.Map<UserForGettingDto>(userToReturn);
                    }
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    if (error != null)
                    {
                        throw new RegistrationFailure(error.Description);
                    }
                    else
                    {
                        throw new RegistrationFailure("An unknown error occurred.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegisterAdmin(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(registrationRequestDto);

            try
            {
                var result = await _userRepository.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _userRepository.GetUserAsync(registrationRequestDto.UserName.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _userRepository.RoleExistsAsync(_adminRole))
                        {
                            await _userRepository.AddToRoleAsync(userToReturn, _adminRole);
                        }

                        var userDto = _mapper.Map<UserForGettingDto>(userToReturn);
                    }
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    if (error != null)
                    {
                        throw new RegistrationFailure(error.Description);
                    }
                    else
                    {
                        throw new RegistrationFailure("An unknown error occurred.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}