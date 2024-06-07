using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Topic;
using Application.Service.Mapper;
using AutoMapper;
using ForumProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Claims;

namespace Application.Service.Implimentations.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopicService(ITopicRepository topicRepository, IHttpContextAccessor httpContextAccessor, MappingProfile mappingProfile)
        {
            _httpContextAccessor = httpContextAccessor;
            _topicRepository = topicRepository;
            _mapper = mappingProfile.InitializeTopic();
        }

        public async Task CreateTopicAsync(TopicForCreatingDto topicForCreatingDto)
        {
            if (topicForCreatingDto is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }            
            var result = _mapper.Map<Topic>(topicForCreatingDto);
            var userId = AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to create topic");
            }
            result.UserId = userId;
            await _topicRepository.AddAsync(result);
            await _topicRepository.Save();
        }

        public async Task<List<TopicForGettingDto>> GetAllTopicsAsync()
        {
            var raw = await _topicRepository.GetAllAsync(includePropeties: "Comments,ApplicationUser");
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

            var raw = await _topicRepository.GetAllAsync(x => x.UserId.Trim() == userId.Trim(), includePropeties: "Comments,ApplicationUser");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Topics not found");
            }
            var topics = _mapper.Map<List<TopicForGettingDto>>(raw);
            return topics;
        }

        public async Task UpdateTopicAsyncAdmin(Guid id, JsonPatchDocument<TopicForUpdatingDtoAdmin> patchDocument)
        {
            if (patchDocument is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var userId = AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update state of topic");
            }
            var userRole = AuthenticatedUserRole();
            if (userRole != "Admin".Trim())
            {
                throw new UnauthorizedAccessException("Must be an admin to update state of topic");
            }
            var topicFromDb = await _topicRepository.GetAsync(x => x.Id == id);
            if (topicFromDb is null)
            {
                throw new ArgumentNullException("Topic does not exist");
            }
            var topicToPatch = _mapper.Map<TopicForUpdatingDtoAdmin>(topicFromDb);
            patchDocument.ApplyTo(topicToPatch);
            _mapper.Map(topicToPatch, topicFromDb);

            await _topicRepository.Save();
        }

        public async Task UpdateTopicAsyncUser(Guid id, JsonPatchDocument<TopicForUpdatingDtoUser> patchDocument)
        {
            if (patchDocument is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var userId = AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update topic");
            }
            var topicFromDb = await _topicRepository.GetAsync(x => x.Id == id);
            if (topicFromDb is null)
            {
                throw new ArgumentNullException("Topic does not exist");
            }
            if (topicFromDb.UserId != userId)
            {
                throw new UnauthorizedAccessException("Can't update another users topic");
            }
            var topicToPatch = _mapper.Map<TopicForUpdatingDtoUser>(topicFromDb);
            patchDocument.ApplyTo(topicToPatch);
            _mapper.Map(topicToPatch, topicFromDb);
            
            await _topicRepository.Save();
        }
        private string AuthenticatedUserId()
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
        private string AuthenticatedUserRole()
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

    }
}
