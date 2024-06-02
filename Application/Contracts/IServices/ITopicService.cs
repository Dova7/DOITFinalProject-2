using Application.Models.Main.Dtos.Topic;

namespace Application.Contracts.IServices
{
    public interface ITopicService
    {
        Task<List<TopicForGettingDto>> GetAllTopicsAsync();
        Task<List<TopicForGettingDto>> GetAllTopicsOfUserAsync(string userId);
    }
}
