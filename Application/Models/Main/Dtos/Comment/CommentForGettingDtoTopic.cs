namespace Application.Models.Main.Dtos.Comment
{
    public class CommentForGettingDtoTopic
    {
        public string Body { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public string DisplayName { get; set; } = null!;
    }
}
