using Domain.Constants.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;

        public ICollection<Comment>? Comments { get; set; }
    }
}
