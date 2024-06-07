namespace Application.Models.Main.Dtos.Comment
{
    public class CommentForGettingDtoMain
    {
        public Guid Id { get; set; }
        public string Body { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public string TopicTitle { get; set; } = null!;
    }
}
