using ForumProject.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = null!;
        public ICollection<Topic>? Topics { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}