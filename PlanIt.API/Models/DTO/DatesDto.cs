using System.ComponentModel.DataAnnotations;

namespace PlanIt.API.Models.DTO
{
    public class DatesDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}
