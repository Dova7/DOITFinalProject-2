using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Topic;
using Application.Service.Exceptions;
using Application.Service.Mapper;
using AutoMapper;
using ForumProject.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Service.Implimentations.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TopicService(ITopicRepository topicRepository, MappingProfile mappingProfile, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _topicRepository = topicRepository;
            _mapper = mappingProfile.InitializeTopic();
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task CreateTopicAsync(TopicForCreatingDto topicForCreatingDto)
        {
            if (topicForCreatingDto is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<Topic>(topicForCreatingDto);
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to create topic");
            }
            result.UserId = userId;
            await _topicRepository.AddAsync(result);
            await _topicRepository.Save();
        }

        public async Task DeactivateInactiveTopicsAsync()
        {
            var inactiveThreshold = DateTime.UtcNow.AddDays(-30);

            var topics = await _topicRepository.GetAllAsync(includePropeties: "Comments");

            foreach (var topic in topics)
            {
                var lastCommented = topic.Comments?.OrderByDescending(c => c.PostDate).FirstOrDefault()?.PostDate ?? topic.PostDate;
                if (lastCommented <= inactiveThreshold)
                {
                    topic.Status = false;
                }
            }
            await _topicRepository.Save();


        }

        public async Task DeleteTopicAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            var raw = await _topicRepository.GetAsync(x => x.Id == id, includePropeties: "Comments,ApplicationUser");
            if (raw == null)
            {
                throw new TopicNotFoundException("Topic not Found");
            }
            var userId = _userRepository.AuthenticatedUserId();
            var userRole = _userRepository.AuthenticatedUserRole().Trim();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update state of topic");
            }
            if (raw.UserId.Trim() != userId && userRole != "Admin")
            {
                throw new InvalidUserException("Can't delete different users topic");
            }
            else
            {
                if (raw.Comments != null)
                {
                    _commentRepository.RemoveRange(raw.Comments);
                    await _commentRepository.Save();
                }
                _topicRepository.Remove(raw);
                await _topicRepository.Save();
            }
        }

        public async Task<List<TopicForGettingDtoAll>> GetAllTopicsAsync()
        {
            var raw = await _topicRepository.GetAllAsync(includePropeties: "Comments,ApplicationUser");
            if (raw.Count == 0)
            {
                throw new TopicNotFoundException("Topics not Found");
            }
            var filteredRaw = raw.Where(t => t.State == Domain.Constants.Enums.State.Show).ToList();
            if (filteredRaw.Count == 0)
            {
                throw new TopicNotFoundException("Topics with show state not Found");
            }
            var topics = _mapper.Map<List<TopicForGettingDtoAll>>(filteredRaw);
            return topics;
        }

        public async Task<List<TopicForGettingDtoAll>> GetAllTopicsOfUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("Invalid argument passed");
            }

            var raw = await _topicRepository.GetAllAsync(x => x.UserId.Trim() == userId.Trim(), includePropeties: "Comments,ApplicationUser");
            if (raw.Count == 0)
            {
                throw new TopicNotFoundException("Topics not Found");
            }
            var filteredRaw = raw.Where(t => t.State == Domain.Constants.Enums.State.Show).ToList();
            if (filteredRaw.Count == 0)
            {
                throw new TopicNotFoundException("Topics with show state not Found");
            }
            var topics = _mapper.Map<List<TopicForGettingDtoAll>>(filteredRaw);
            return topics;
        }

        public async Task<TopicForGettingDto> GetSingleTopicAsync(Guid id)
        {
            var raw = await _topicRepository.GetAsync(x => x.Id == id, includePropeties: "Comments.ApplicationUser,ApplicationUser");
            if (raw is null)
            {
                throw new TopicNotFoundException("Topic not Found");
            }
            if (raw.State != Domain.Constants.Enums.State.Show)
            {
                throw new TopicNotFoundException("Topic is Hidden");
            }
            var topic = _mapper.Map<TopicForGettingDto>(raw);
            return topic;
        }

        public async Task UpdateTopicAsyncAdmin(Guid id, JsonPatchDocument<TopicForUpdatingDtoAdmin> patchDocument)
        {
            if (patchDocument is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update state of topic");
            }
            var userRole = _userRepository.AuthenticatedUserRole();
            if (userRole != "Admin".Trim())
            {
                throw new UnauthorizedAccessException("Must be an admin to update state of topic");
            }
            var topicFromDb = await _topicRepository.GetAsync(x => x.Id == id);
            if (topicFromDb is null)
            {
                throw new TopicNotFoundException("Topic not Found");
            }            
            var topicToPatch = _mapper.Map<TopicForUpdatingDtoAdmin>(topicFromDb);
            patchDocument.ApplyTo(topicToPatch);
            _mapper.Map(topicToPatch, topicFromDb);

            await _topicRepository.Save();
        }

        public async Task UpdateTopicAsyncState(Guid id, JsonPatchDocument<TopicForUpdatingDtoState> patchDocument)
        {
            if (patchDocument is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            byte show = 2;
            byte hide = 3;
            if (patchDocument.Operations.Any(op => op.value.ToString() != show.ToString() && op.value.ToString() != hide.ToString()))
            {
                throw new InvalidStateException();
            }
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update topic");
            }
            var topicFromDb = await _topicRepository.GetAsync(x => x.Id == id);
            if (topicFromDb is null)
            {
                throw new TopicNotFoundException("Topic not Found");
            }
            if (topicFromDb.Status == false)
            {
                throw new TopicIsInactiveException();
            }
            if (topicFromDb.UserId != userId)
            {
                throw new InvalidUserException("Can't update another users topic");
            }
            var topicToPatch = _mapper.Map<TopicForUpdatingDtoState>(topicFromDb);
            patchDocument.ApplyTo(topicToPatch);
            _mapper.Map(topicToPatch, topicFromDb);

            await _topicRepository.Save();
        }

        public async Task UpdateTopicAsyncUser(Guid id, TopicForUpdatingDtoUser topicForUpdatingDtoUser)
        {
            if (topicForUpdatingDtoUser is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var authenticatedId = _userRepository.AuthenticatedUserId();
            if (authenticatedId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update Topic");
            }
            var topicFromDb = await _topicRepository.GetAsync(x => x.Id == id);
            if (topicFromDb is null)
            {
                throw new TopicNotFoundException("Topic not Found");
            }
            if (topicFromDb.Status == false)
            {
                throw new TopicIsInactiveException();
            }
            if (topicFromDb.UserId != authenticatedId)
            {
                throw new UnauthorizedAccessException("Can't update another users topic");
            }
            var updatedTopic = _mapper.Map<Topic>(topicForUpdatingDtoUser);
            updatedTopic.Id = id;
            await _topicRepository.Update(updatedTopic);
            await _topicRepository.Save();
        }
    }
}
