using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlanIt.API.Models.DTO;
using PlanIt.API.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PlanIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IMapper mapper, IConfiguration configuration )
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _configuration = configuration;
        }


        //Post: /api/auth/register

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] RequestRegisterDto requestRegisterDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = requestRegisterDto.Name,
                Email = requestRegisterDto.Email
            };



            var identityResult = await _userManager.CreateAsync(identityUser, requestRegisterDto.Password);


            if (identityResult.Succeeded)
            {
                    identityResult = await _userManager.AddToRoleAsync(identityUser, "guest");
                      
                    if (identityResult.Succeeded)
                    {
                        return Ok();
                    }
                
            }
            return BadRequest();

        }




        //POST: /api/auth/login
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            

            if (user != null)
            {
                var  checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    if (userRoles != null)
                    {
                        var jwtToken = _tokenRepository.CreateJWTToken(user, userRoles.ToList());

                        var cookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = false,
                            SameSite = SameSiteMode.Lax,
                            Expires = DateTime.UtcNow.AddDays(7)
                        };

                        Response.Cookies.Append("jwtToken", jwtToken, cookieOptions);

                        var response = new LoginResponseDto
                        {
                            UserId = user.Id,
                            UserRole = userRoles.FirstOrDefault(),
                            UserName = user.UserName,
                            Email = user.Email
                        };


                        return Ok(response);
                    }

                    

                }
            }

            return BadRequest("Username or password is incorrect");
        }


        [HttpGet]
        [Route("authorize")]
        
        public IActionResult Authorize()
        {
            var jwtToken = Request.Cookies["jwtToken"];

            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized(new { message = "Not authenticated" });
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);


                return Ok(new { message = "Authenticated" });
            }
            catch
            {
                return Unauthorized(new { message = "Not authenticated" });
            }
            
        }

        [HttpPost]
        [Route("logout")]

        public IActionResult Logout()
        {
            var jwtToken = Request.Cookies["jwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return BadRequest(new { message = "No jwtToken cookie found" });
            }
            Response.Cookies.Delete("jwtToken");
            return Ok(new { message = "logged out" });
        }


    }
}
