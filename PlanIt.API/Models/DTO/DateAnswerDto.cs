using PlanIt.API.Models.Domain;

namespace PlanIt.API.Models.DTO
{
    public class DateAnswerDto
    {
        public Guid DateId { get; set; }
        public bool Answer { get; set; }

        public Dates? Date { get; set; }

    }
}
