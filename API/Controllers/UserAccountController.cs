using API.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly AuthService authService;

        public UserAccountController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestBody loginRequest)
        {
            if (loginRequest == null) return BadRequest();
            var token = await authService.Login(loginRequest.userName, loginRequest.password);
            if (token == null) return BadRequest();
            HttpContext.Response.Cookies.Append("cookies", token);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Registration([FromBody] RegistrationRequestBody registrationRequest)
        {
            if (registrationRequest == null)
                return BadRequest();
            var result = await authService.Registration(registrationRequest.userName, registrationRequest.password);
            return result ? Ok() : BadRequest();
        }

    }
}