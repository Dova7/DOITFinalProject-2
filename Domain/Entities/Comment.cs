using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumProject.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Topic))]
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;


    }
}
