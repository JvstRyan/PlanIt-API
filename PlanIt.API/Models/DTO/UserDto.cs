using PlanIt.API.Models.Domain;

namespace PlanIt.API.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }
    }
}
