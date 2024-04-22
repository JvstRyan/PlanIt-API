namespace PlanIt.API.Models.DTO
{
    public class ActiveDateDto
    {
        public Guid DateId { get; set; }
        public DateTime Date { get; set; }
        public List<ResponseUserDto> AvailableUsers { get; set; }
    }
}
