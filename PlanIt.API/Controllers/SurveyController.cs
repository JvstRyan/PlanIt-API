using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;
using PlanIt.API.Repositories.Interfaces;

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



        //Create survey by collection all dates from body

        //POST: https://localhost:7220/api/survey
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddDatesRequestDto addDatesRequestDto)
        {

            var dates = new List<Dates>();

            foreach (var date in addDatesRequestDto.Dates)
            {
                var dateDomainModel = new Dates
                {
                    Date = date,
                    Status = "active"
                };

                dates.Add(dateDomainModel);
            }

            var domainDates = await _surveyRepository.CreateAsync(dates);


            return Ok(_mapper.Map<List<DatesDto>>(domainDates));
           
        }


    }
}



