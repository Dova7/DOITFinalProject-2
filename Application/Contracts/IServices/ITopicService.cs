using Application.Models.Main.Dtos.Topic;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts.IServices
{
    public interface ITopicService
    {
        Task<List<TopicForGettingDtoAll>> GetAllTopicsAsync();
        Task<List<TopicForGettingDtoAll>> GetAllTopicsOfUserAsync(string userId);
        Task<TopicForGettingDto> GetSingleTopicAsync(Guid id);
        Task CreateTopicAsync(TopicForCreatingDto topicForCreatingDto);
        Task UpdateTopicAsyncUser(Guid id, TopicForUpdatingDtoUser topicForUpdatingDtoUser);
        Task UpdateTopicAsyncAdmin(Guid id, JsonPatchDocument<TopicForUpdatingDtoAdmin> patchDocument);
        Task UpdateTopicAsyncState(Guid id, JsonPatchDocument<TopicForUpdatingDtoState> patchDocument);
        Task DeleteTopicAsync(Guid id);
        Task DeactivateInactiveTopicsAsync();
    }
}
