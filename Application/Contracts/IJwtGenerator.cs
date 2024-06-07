using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts
{
    public interface IJwtGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
