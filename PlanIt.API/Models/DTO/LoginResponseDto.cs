namespace PlanIt.API.Models.DTO
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }

        public string UserId { get; set; }
        public string UserRole { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
