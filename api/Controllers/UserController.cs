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


        // [Route("test")]
        // [HttpGet]
        // public IActionResult Test() {
        //     return new OkObjectResult("This is a test");
        // }

        [Route("")]
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = this.userService.GetUser();
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