using System.ComponentModel.DataAnnotations;

namespace PlanIt.API.Models.Domain
{
    public class Dates
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public required string Status { get; set; }
    }
}
