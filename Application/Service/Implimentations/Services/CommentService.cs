using Application.Contracts.IRepositories;
using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Comment;
using Application.Service.Exceptions;
using Application.Service.Mapper;
using AutoMapper;
using ForumProject.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Service.Implimentations.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository, MappingProfile mappingProfile, IUserRepository userRepository, ITopicRepository topicRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mappingProfile.InitializeComment();
            _userRepository = userRepository;
            _topicRepository = topicRepository;
        }
        public async Task CreateCommentAsync(Guid topicId, CommentForCreatingDto commentForCreatingDto)
        {
            if (topicId == Guid.Empty)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            if (commentForCreatingDto is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var topicFromDb = await _topicRepository.GetAsync(x=>x.Id == topicId);
            if (topicFromDb is null)
            {
                throw new TopicNotFoundException("Topic not Found"); 
            }
            if (topicFromDb.Status == false)
            {
                throw new TopicIsInactiveException();
            }
            var result = _mapper.Map<Comment>(commentForCreatingDto);
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to create Comment");
            }            
            result.UserId = userId;
            result.TopicId = topicId;            

            await _commentRepository.AddAsync(result);
            await _commentRepository.Save();
        }
        public async Task DeleteCommentAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            var raw = await _commentRepository.GetAsync(x => x.Id == id);
            if (raw == null)
            {
                throw new CommentNotFoundException();
            }
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update state of comment");
            }
            if (raw.UserId.Trim() != userId && _userRepository.AuthenticatedUserRole().Trim() != "Admin")
            {
                throw new InvalidUserException("Can't delete different users comment");
            }
            else
            {
                _commentRepository.Remove(raw);
                await _commentRepository.Save();
            }
        }
        public async Task<List<CommentForGettingDtoMain>> GetAllCommentsOfUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("Invalid argument passed");
            }

            var raw = await _commentRepository.GetAllAsync(x => x.UserId.Trim() == userId.Trim(), includePropeties: "Topic");
            if (raw.Count == 0)
            {
                throw new CommentNotFoundException();
            }
            var comments = _mapper.Map<List<CommentForGettingDtoMain>>(raw);
            return comments;
        }
        public async Task UpdateCommentAsync(Guid id, JsonPatchDocument<CommentForUpdatingDto> patchDocument)
        {
            if (patchDocument is null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var userId = _userRepository.AuthenticatedUserId();
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Must be logged in to update topic");
            }
            var commentFromDb = await _commentRepository.GetAsync(x => x.Id == id);
            if (commentFromDb is null)
            {
                throw new CommentNotFoundException();
            }
            if (commentFromDb.UserId != userId)
            {
                throw new InvalidUserException("Can't update another users topic");
            }
            var commentToPatch = _mapper.Map<CommentForUpdatingDto>(commentFromDb);
            patchDocument.ApplyTo(commentToPatch);
            _mapper.Map(commentToPatch, commentFromDb);

            await _commentRepository.Save();
        }
    }
}
