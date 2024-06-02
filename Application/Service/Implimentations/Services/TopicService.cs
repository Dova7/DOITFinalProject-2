using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Topic;
using Application.Service.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Service.Implimentations.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopicService(ITopicRepository topicRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _topicRepository = topicRepository;
            _mapper = MappingProfile.InitializeTopic();
        }
        public async Task<List<TopicForGettingDto>> GetAllTopicsAsync()
        {
            var raw = await _topicRepository.GetAllAsync(includePropeties: "Comments,IdentityUser");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Topics not found");
            }
            var topics = _mapper.Map<List<TopicForGettingDto>>(raw);
            return topics;
        }

        public async Task<List<TopicForGettingDto>> GetAllTopicsOfUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("Invalid argument passed");
            }

            var raw = await _topicRepository.GetAllAsync(includePropeties: "Comments,IdentityUser");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Topics not found");
            }
            var topics = _mapper.Map<List<TopicForGettingDto>>(raw);
            return topics;
        }
    }
}
