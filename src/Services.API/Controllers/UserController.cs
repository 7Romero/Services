using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.User;
using System.Security.Claims;

namespace Services.API.Controllers
{
    [Route("api/user")]
    public class UserController : AppBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userName}")]
        public async Task<UserDto> GetUser(string userName)
        {
            var UserDto = await _userService.GetUser(userName);

            return UserDto;
        }

/*        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateUser(UserForUpdateDto userForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserDto = await _userService.CreateUser(userForUpdateDto);

            return CreatedAtAction(nameof(GetUser), new { id = UserDto.Id }, UserDto);
        }*/

        [HttpPut("Admin/{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateUserAdmin(Guid id, UserForUpdateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.UpdateUser(id, userDto);

            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUser(UserForUpdateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = new Guid(userId);

            await _userService.UpdateUser(id, userDto);

            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
        }
    }
}
