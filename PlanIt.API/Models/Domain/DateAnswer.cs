using System.Text.Json.Serialization;

namespace PlanIt.API.Models.Domain
{
    public class DateAnswer
    {
        public Guid Id { get; set; }
        public Guid DateId { get; set; }
        public bool Answer { get; set; }

        public Dates? Date { get; set; }
        public Guid ResponseId { get; set; }
        public Response Response { get; set; }


    }
}





