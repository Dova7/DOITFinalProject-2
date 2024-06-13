using Application.Models.Identity.Dtos;
using Application.Models.Main.Dtos.Comment;
using Application.Models.Main.Dtos.Topic;
using AutoMapper;
using Domain.Entities.Identity;
using ForumProject.Entities;

namespace Application.Service.Mapper
{
    public class MappingProfile
    {
        public MappingProfile()
        {

        }

        public static IMapper InitializeUser()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<UserForGettingDtoLogin, ApplicationUser>().ReverseMap();
                config.CreateMap<UserForGettingDto, ApplicationUser>()
                .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments))
                .ForMember(d => d.Topics, o => o.MapFrom(s => s.Topics))
                .ReverseMap();

                config.CreateMap<Topic, TopicForGettingDtoAll>()
                .ForMember(d => d.CommentCount, o => o.MapFrom(s => s.Comments != null ? s.Comments.Count() : 0))
                .ReverseMap();
                config.CreateMap<Comment, CommentForGettingDtoMain>();

                config.CreateMap<Topic, TopicForGettingDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.ApplicationUser.DisplayName))
                .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments))
                .ReverseMap();

                config.CreateMap<Comment, CommentForGettingDtoTopic>()
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.ApplicationUser.DisplayName))
                .ReverseMap();

                config.CreateMap<UserForUpdatingDto, ApplicationUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDto, ApplicationUser>()
                .ForMember(destination => destination.DisplayName, options => options.MapFrom(source => source.DisplayName))
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.UserName))
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
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Comment, CommentForGettingDtoTopic>()
                    .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                    .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.ApplicationUser.DisplayName))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForGettingDtoAll>()
                    .ForMember(d => d.CommentCount, o => o.MapFrom(s => s.Comments != null ? s.Comments.Count() : 0))
                    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.ApplicationUser.DisplayName))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForGettingDto>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                    .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                    .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.ApplicationUser.DisplayName))
                    .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForCreatingDto>()
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForUpdatingDtoUser>()
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForUpdatingDtoState>()
                    .ForMember(d => d.State, o => o.MapFrom(s => s.State))
                    .ReverseMap();

                config.CreateMap<Topic, TopicForUpdatingDtoAdmin>()
                    .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                    .ReverseMap();
            });

            return configuration.CreateMapper();
        }

        public IMapper InitializeComment()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<Comment, CommentForGettingDtoMain>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.PostDate, o => o.MapFrom(s => s.PostDate))
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ForMember(d => d.TopicTitle, o => o.MapFrom(s => s.Topic.Title))
                .ReverseMap();

                config.CreateMap<Comment, CommentForCreatingDto>()
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ReverseMap();

                config.CreateMap<Comment, CommentForUpdatingDto>()
                .ForMember(d => d.Body, o => o.MapFrom(s => s.Body))
                .ReverseMap();
            });
            return configuration.CreateMapper();
        }
    }
}
