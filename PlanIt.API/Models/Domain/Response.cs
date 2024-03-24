namespace PlanIt.API.Models.Domain
{
    public class Response
    {
        public Guid Id { get; set; }

        public Guid DateId { get; set; }

        public Guid UserId { get; set; }


        //Navigation properties

        public ApplicationUser User { get; set; }
        public Dates Date { get; set; }


    }
}
