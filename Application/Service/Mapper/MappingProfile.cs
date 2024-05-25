using Application.Models.Identity.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Service.Mapper
{
    public class MappingProfile
    {
        public MappingProfile()
        {

        }

        public static IMapper Initialize()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<UserDto, IdentityUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDto, IdentityUser>()
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.PhoneNumber, options => options.MapFrom(source => source.PhoneNumber))
                .ReverseMap();

            });
            return configuration.CreateMapper();
        }
    }
}
