using System.ComponentModel.DataAnnotations;

namespace Application.Models.Main.Dtos.Topic
{
    public class TopicForUpdatingDtoAdmin
    {
        [Required]
        public bool Status { get; set; }
    }
}
