using Microsoft.AspNetCore.Identity;
using PlanIt.API.Models.Domain;

namespace PlanIt.API.Models.DTO
{
    public class ResponseDto
    {
        public string UserId { get; set; }

        //Navigation properties
        public string UserName { get; set; }
        public List<DateAnswerDto> DateAnswers { get; set; }
    }
}
