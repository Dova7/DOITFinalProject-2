namespace Application.Models.Main.Dtos.Comment
{
    public class CommentForGettingDto
    {
        public string Body { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public string UserName { get; set; } = null!;
    }
}
