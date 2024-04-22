using Microsoft.AspNetCore.Identity;

namespace PlanIt.API.Repositories
{
    public interface ITokenRepository
    {
      string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}
