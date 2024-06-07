using Application.Models.Main.Dtos.Comment;
using Application.Models.Main.Dtos.Topic;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts.IServices
{
    public interface ICommentService
    {
        Task<List<CommentForGettingDtoMain>> GetAllCommentsOfUserAsync(string userId);
        Task CreateCommentAsync(Guid topicId, CommentForCreatingDto commentForCreatingDto);
        Task UpdateCommentAsync(Guid id, JsonPatchDocument<CommentForUpdatingDto> patchDocument);
        Task DeleteCommentAsync(Guid id);
    }
}
