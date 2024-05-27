using Microsoft.AspNetCore.Identity;

namespace PlanIt.API.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Response> Responses { get; set; }
    }
}
