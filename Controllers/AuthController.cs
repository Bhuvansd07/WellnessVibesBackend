using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Models.Auth;
using WebApplication1.Services.AuthService;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase{

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {

            User loggedInUser = await _authService.Login(user.UserName, user.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser user)
        {
     

            User userToRegister = new(user.UserName, user.Name, user.Password);

            User registeredUser = await _authService.Register(userToRegister);

            User loggedInUser = await _authService.RegiserUser(registeredUser);

            if (loggedInUser != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("token", loggedInUser.Token);
                _authService.insertUser(loggedInUser);
                return Ok(response);
            }
            return BadRequest(new { message = "User Already Exist" });
        }

    }
}
