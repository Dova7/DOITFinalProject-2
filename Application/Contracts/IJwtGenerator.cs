using Microsoft.AspNetCore.Identity;

namespace Application.Contracts
{
    public interface IJwtGenerator
    {
        string GenerateToken(IdentityUser applicationUser, IEnumerable<string> roles);
    }
}
