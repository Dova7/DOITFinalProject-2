using Application.Contracts;
using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Identity.Dtos;
using Application.Service.Exceptions;
using Application.Service.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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
            _mapper = MappingProfile.InitializeAuth();
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetUserAsync(loginRequestDto.UserName.ToLower());
            bool isValid = await _userRepository.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    Token = string.Empty,
                    User = null
                };
            }

            var roles = await _userRepository.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDto = _mapper.Map<UserDto>(user);

            LoginResponseDto result = new()
            {
                User = userDto,
                Token = token
            };
            return result;
        }

        public async Task Register(RegistrationRequestDto registrationRequestDto)
        {
            IdentityUser user = _mapper.Map<IdentityUser>(registrationRequestDto);

            try
            {
                var result = await _userRepository.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _userRepository.GetUserAsync(registrationRequestDto.Email.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _userRepository.RoleExistsAsync(_userRole))
                        {
                            await _userRepository.AddToRoleAsync(userToReturn, _userRole);
                        }

                        UserDto userDto = _mapper.Map<UserDto>(userToReturn);
                    }
                }
                else
                {
                    throw new RegistrationFailure(result.Errors.FirstOrDefault().Description);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegisterAdmin(RegistrationRequestDto registrationRequestDto)
        {
            IdentityUser user = _mapper.Map<IdentityUser>(registrationRequestDto);

            try
            {
                var result = await _userRepository.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _userRepository.GetUserAsync(registrationRequestDto.Email.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _userRepository.RoleExistsAsync(_adminRole))
                        {
                            await _userRepository.AddToRoleAsync(userToReturn, _adminRole);
                        }

                        UserDto userDto = _mapper.Map<UserDto>(userToReturn);
                    }
                }
                else
                {
                    throw new RegistrationFailure(result.Errors.FirstOrDefault().Description);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}