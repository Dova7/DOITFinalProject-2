using System.ComponentModel.DataAnnotations;

namespace Application.Models.Main.Dtos.Topic
{
    public class TopicForCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(10000)]
        public string Body { get; set; } = null!;

        [Required]
        public string UserId { get; set; }
    }
}
