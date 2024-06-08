using Microsoft.AspNetCore.Identity;
using PlanIt.API.Models.Domain;

namespace PlanIt.API.Services.Interfaces
{
    public interface IUserService
    {

        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);





    }
}
