using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIt.API.Models.DTO;
using PlanIt.API.Repositories;

namespace PlanIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;

        public SurveyController(IMapper mapper, ISurveyRepository surveyRepository)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
        }

        //Get all dates by status 
        //GET: https://localhost:7220/api/survey

        [HttpGet]

        public async Task<IActionResult> GetAllActive()
        {
            var activeDates = await _surveyRepository.GetAllActiveAsync();

            return Ok(_mapper.Map<List<DatesDto>>(activeDates));
        }


    }
}
