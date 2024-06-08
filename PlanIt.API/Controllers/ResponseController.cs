using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;
using PlanIt.API.Repositories;

namespace PlanIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IResponseRepository _responseRepository;
        private readonly IMapper _mapper;

        public ResponseController(UserManager<ApplicationUser> userManager, IResponseRepository responseRepository, IMapper mapper)
        {
            _userManager = userManager;
            _responseRepository = responseRepository;
            _mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> GetSurveyResults()
        {
            var results = await _responseRepository.GetAllResponses();


            return Ok(results);
        }

        [HttpGet("users")]

        public async Task<IActionResult> GetActiveUsers()
        {
            var responses = await _responseRepository.GetAllResponses();

            var users = responses.SelectMany(r => r.AvailableUsers)
                .GroupBy(u => u.UserId)
                .Select(g => g.First())
                .ToList();

            return Ok(users);
        }

        [HttpPost]

        public async Task<IActionResult> CreateResponse([FromBody] AddResponseDto addResponseDto)
        {
            var user = await _userManager.FindByIdAsync(addResponseDto.UserId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var domainResponse = _mapper.Map<Response>(addResponseDto);

            await _responseRepository.CreateResponse(domainResponse);


            return StatusCode(201, "Response has been stored");

           
        }

        [HttpGet("hasUserAnswered")]

        public async Task<IActionResult> HasUserAnswered(string userId)
        {
            bool hasAnswered = await _responseRepository.HasUserAnswered(userId);

            return Ok(hasAnswered);
        }

    }
}




