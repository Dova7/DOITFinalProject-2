using Domain.Constants.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Main.Dtos.Topic
{
    public class TopicForUpdatingDtoState
    {
        [Required]
        public State State { get; set; }
    }
}
