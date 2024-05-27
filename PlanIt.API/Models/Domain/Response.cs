using Microsoft.AspNetCore.Identity;

namespace PlanIt.API.Models.Domain
{
    public class Response
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }


        //Navigation properties

        public ApplicationUser User { get; set; }
        public List<DateAnswer> DateAnswers { get; set; }


    }
}





