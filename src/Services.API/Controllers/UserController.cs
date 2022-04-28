using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.User;

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

        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(Guid id)
        {
            var UserDto = await _userService.GetUser(id);
            return UserDto;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(UserForUpdateDto userForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserDto = await _userService.CreateUser(userForUpdateDto);

            return CreatedAtAction(nameof(GetUser), new { id = UserDto.Id }, UserDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, UserForUpdateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.UpdateUser(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(Guid id)
        {
            await _userService.DeleteUser(id);
        }
    }
}
