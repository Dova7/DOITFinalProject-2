using System.ComponentModel.DataAnnotations;

namespace Application.Models.Main.Dtos.Comment
{
    public class CommentForCreatingDto
    {
        [Required]
        [MaxLength(10000)]
        public string Body { get; set; } = null!;
    }
}
