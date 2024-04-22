using Microsoft.AspNetCore.Identity;
using PlanIt.API.Models.Domain;

namespace PlanIt.API.Models.DTO
{
    public class AddResponseDto
    {
        public string UserId { get; set; }


        //Navigation properties

        public List<DateAnswerDto> DateAnswers { get; set; }
    }
}
