using Domain.Constants.Enums;
using Domain.Entities;
using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumProject.Entities
{
    public class Topic : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        public State State { get; set; } = State.Pending;

        [Required]
        public bool Status { get; set; } = true;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public ICollection<Comment>? Comments { get; set; }
    }
}
