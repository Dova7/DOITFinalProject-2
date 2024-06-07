using Application.Models.Main.Dtos.Topic;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts.IServices
{
    public interface ITopicService
    {
        Task<List<TopicForGettingDto>> GetAllTopicsAsync();
        Task<List<TopicForGettingDto>> GetAllTopicsOfUserAsync(string userId);
        Task CreateTopicAsync(TopicForCreatingDto topicForCreatingDto);
        Task UpdateTopicAsyncUser(Guid id, JsonPatchDocument<TopicForUpdatingDtoUser> patchDocument);
        Task UpdateTopicAsyncAdmin(Guid id, JsonPatchDocument<TopicForUpdatingDtoAdmin> patchDocument);
        Task DeleteTopicAsync(Guid id);
    }
}
