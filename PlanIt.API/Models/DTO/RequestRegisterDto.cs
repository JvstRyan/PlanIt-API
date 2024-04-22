using System.ComponentModel.DataAnnotations;

namespace PlanIt.API.Models.DTO
{
    public class RequestRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
