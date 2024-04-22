using System.ComponentModel.DataAnnotations;

namespace PlanIt.API.Models.DTO
{
    public class UpdateUserDto
    {
       
        
        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Roles { get; set; }


    }
}
