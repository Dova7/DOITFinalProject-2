using Application.Models.Identity.Dtos;
using Application.Models.Main.Dtos.Comment;
using Application.Models.Main.Dtos.Topic;
using AutoMapper;
using ForumProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Service.Mapper
{
    public class MappingProfile
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MappingProfile(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static IMapper InitializeAuth()
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

        public IMapper InitializeTopic()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<Comment, CommentForGettingDto>()
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.IdentityUser.UserName))
                .ReverseMap();

                config.CreateMap<Topic, TopicForGettingDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.IdentityUser.UserName))
                .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments))
                .ReverseMap();

                config.CreateMap<Topic, TopicForCreatingDto>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ReverseMap();

                config.CreateMap<Topic, TopicForUpdatingDtoUser>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ReverseMap();

                config.CreateMap<Topic, TopicForUpdatingDtoAdmin>()
                .ForMember(d => d.State, o => o.MapFrom(s => s.State))
                .ReverseMap();
            });
            return configuration.CreateMapper();
        }
    }
}
