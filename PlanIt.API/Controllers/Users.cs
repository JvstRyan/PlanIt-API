using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;
using PlanIt.API.Repositories;

namespace PlanIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IResponseRepository _responseRepository;

        public Users(UserManager<ApplicationUser> userManager, IMapper mapper, IResponseRepository responseRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseRepository = responseRepository;
        }

        //Get Users
        [HttpGet]
        [Route("users")]

        public async Task<IActionResult> GetUsers()
        {

            var users = await _userManager.Users.ToListAsync();

            if (users != null)
            {
                var userDtos = new List<UserDto>();

                foreach (var user in users)
                {
                    var userDto = _mapper.Map<UserDto>(user);
                    userDto.Roles = await _userManager.GetRolesAsync(user);
                    userDtos.Add(userDto);

                }


                return Ok(userDtos);
            }


            return BadRequest("No users found");


        }



        //Update User 
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto, [FromRoute] string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (!String.IsNullOrEmpty(updateUserDto.Name))
            {
                user.UserName = updateUserDto.Name;
            }


            if (!String.IsNullOrEmpty(updateUserDto.Email))
            {
                user.Email = updateUserDto.Email;
            }



            var updatedResult = await _userManager.UpdateAsync(user);

            if (!updatedResult.Succeeded)
            {
                return BadRequest(updatedResult.Errors);
            }

            if (updateUserDto.Roles != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                if (currentRoles.Count > 0)
                {
                    var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (!removeRoleResult.Succeeded)
                    {
                        return BadRequest(removeRoleResult.Errors);
                    }
                }


                var addRoleResult = await _userManager.AddToRoleAsync(user, updateUserDto.Roles);
                if (!addRoleResult.Succeeded)
                {
                    return BadRequest(addRoleResult.Errors);
                }
            }

            return Ok(_mapper.Map<UserDto>(user));

        }



        //Delete User 

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id cannot be null or empty");
            }

            var result = await _responseRepository.DeleteUser(id);

            if (!result)
            {
                return NotFound("User not found");
            }


            return Ok();
        }

    }
}
