using Microsoft.AspNetCore.Identity;

namespace PlanIt.API.Models.Domain
{

    public enum Role
    {
        Admin,
        Volunteer,
        Guest
    }
    public class ApplicationUser : IdentityUser<Guid>
    {
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role[] Roles { get; set; }
    }
}
