using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumProject.Entities
{
    public class Comment : BaseEntity
    {        
        [Required]
        [MaxLength(10000)]
        public string Body { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;
    }
}
