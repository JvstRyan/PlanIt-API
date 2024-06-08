using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;
using PlanIt.API.Services.Interfaces;


namespace PlanIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
  
        public AuthController(IUserService userService, ITokenService tokenService, IMapper mapper, IConfiguration configuration )
        {
            _userService = userService;
            _tokenService = tokenService;
        }


        //Post: /api/auth/register

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] RequestRegisterDto requestRegisterDto)
        {
            var identityUser = new ApplicationUser
            {
                UserName = requestRegisterDto.Name,
                Email = requestRegisterDto.Email
            };



            var identityResult = await _userService.CreateAsync(identityUser, requestRegisterDto.Password);


            if (identityResult.Succeeded)
            {
                    identityResult = await _userService.AddToRoleAsync(identityUser, "guest");
                      
                    if (identityResult.Succeeded)
                    {
                        return Ok();
                    }
                
            }

            return BadRequest(identityResult.Errors);

        }




        //POST: /api/auth/login
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _userService.FindByEmailAsync(loginRequestDto.Email);


                if (user != null && await _userService.CheckPasswordAsync(user, loginRequestDto.Password))
                {
                    var userRoles = await _userService.GetRolesAsync(user);
                    var jwtToken = _tokenService.CreateJWTToken(user, userRoles.ToList());

                    var response = new LoginResponseDto
                    {
                        UserId = user.Id,
                        UserRole = userRoles.FirstOrDefault(),
                        UserName = user.UserName,
                        Email = user.Email,
                        JwtToken = jwtToken
                    };


                    return Ok(response);
                }


                return BadRequest("Username or password is incorrect");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, "An error occured while processing your request.");
            }
       }


    }
}
