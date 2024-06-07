using Application.Models.Main.Dtos.Comment;

namespace Application.Models.Main.Dtos.Topic
{
    public class TopicForGettingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<CommentForGettingDtoTopic>? Comments { get; set; }
    }
}
