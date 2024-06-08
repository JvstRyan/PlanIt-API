using PlanIt.API.Models.Domain;


namespace PlanIt.API.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateJWTToken(ApplicationUser user, IList<string> roles);
    }
}
