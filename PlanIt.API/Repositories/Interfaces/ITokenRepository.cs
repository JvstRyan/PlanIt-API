using Microsoft.AspNetCore.Identity;

namespace PlanIt.API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, IList<string> roles);

    }
}
