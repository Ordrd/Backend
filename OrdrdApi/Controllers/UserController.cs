using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Models;
using OrdrdApi.Services.UserServ;

namespace OrdrdApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
 
        }

        [HttpGet]
        public async Task<ActionResult<UserDto?>> GetUser(string authId)
        {
            var result = await userService.GetUserAsync(authId);
            return Ok(UserDto.FromUser(result));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto user)
        {
            var userMap = Models.User.FromUserDto(user);
            var result = await userService.CreateUserAsync(userMap);
            return Ok(UserDto.FromUser(result));
        }
    }
}