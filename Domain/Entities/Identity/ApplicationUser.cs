using ForumProject.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Topic>? Topics { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}