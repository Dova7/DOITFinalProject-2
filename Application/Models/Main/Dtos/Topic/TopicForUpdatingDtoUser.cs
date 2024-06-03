using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.Main.Dtos.Topic
{
    public class TopicForUpdatingDtoUser
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        public bool Status { get; set; }
        [Required]
        [MaxLength(10000)]
        public string Body { get; set; } = null!;
    }
}
