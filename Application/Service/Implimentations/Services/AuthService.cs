﻿using Application.Contracts;
using Application.Contracts.IServices;
using Application.Models.Identity.Dtos;
using Application.Service.Exceptions;
using Application.Service.Mapper;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Implimentations.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        private const string _adminRole = "Admin";
        private const string _userRole = "User";

        public AuthService(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IJwtGenerator jwtGenerator)
        {
            _context = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtGenerator;
            _mapper = MappingProfile.Initialize();
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    Token = string.Empty,
                    User = null
                };
            }

            var roles = await _userManager.GetRolesAsync(user);
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
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == registrationRequestDto.Email.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _roleManager.RoleExistsAsync(_userRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(_userRole));
                        }

                        await _userManager.AddToRoleAsync(userToReturn, _userRole);

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
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == registrationRequestDto.Email.ToLower());

                    if (userToReturn != null)
                    {
                        if (!await _roleManager.RoleExistsAsync(_adminRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(_adminRole));
                        }

                        await _userManager.AddToRoleAsync(userToReturn, _adminRole);

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