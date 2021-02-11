using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("{userId}")]
        [HttpGet]
        public IActionResult GetUser(int userId)
        {
            var user = this.userService.GetUserById(userId);
            return new OkObjectResult(user);
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetUser([FromQuery] string userName) {
            var user = this.userService.GetUserByUserName(userName);
            return new OkObjectResult(user);
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var req = HttpContext.Request;
            var result = this.userService.CreateUser(createUserDto);
            return new OkResult();
        }
    }
}