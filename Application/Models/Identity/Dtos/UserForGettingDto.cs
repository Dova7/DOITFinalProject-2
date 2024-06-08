using Application.Models.Main.Dtos.Comment;
using Application.Models.Main.Dtos.Topic;

namespace Application.Models.Identity.Dtos
{
    public class UserForGettingDto
    {
        public string Id { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ICollection<TopicForGettingDto>? Topics { get; set; }
        public ICollection<CommentForGettingDtoMain>? Comments { get; set; }
    }
}
