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
        public IActionResult GetUserById(int userId)
        {
            var user = this.userService.GetUserById(userId);
            if (user == null) {
                return NotFound();
            }
            return new OkObjectResult(user);

        }

        [Route("")]
        [HttpGet]
        public IActionResult GetUser([FromQuery] string userName) {
            var user = this.userService.GetUserByUserName(userName);
            if (user == null) {
                return NotFound();
            }
            return new OkObjectResult(user);
        }


        [Route("{userId}/document")]
        [HttpGet]
        public IActionResult GetUser2(int userId) {
            return new BadRequestResult();
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var req = HttpContext.Request;
            var result = this.userService.CreateUser(createUserDto);
            return Ok();
        }


        [Route("login")]
        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginRequestDto loginRequest) {
            var result = this.userService.AuthenticateUser(loginRequest);
            return new OkObjectResult(result);
        }
    }
}