using Application.DTO;
using Application.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IBus _bus;

        public UserAccountController(AuthService authService, IBus bus)
        {
            _authService = authService;
            _bus = bus;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestBody loginRequest)
        {
            if (loginRequest == null) return BadRequest();
            var token = await _authService.Login(loginRequest.userName, loginRequest.password);
            if (token == null) return BadRequest();
            HttpContext.Response.Cookies.Append("cookies", token);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Registration([FromBody] RegistrationRequestBody registrationRequest)
        {
            if (registrationRequest == null)
                return BadRequest();
            var result = await _authService.Registration(registrationRequest.userName, registrationRequest.password);
            if (result != null)
            {
                await _bus.Publish(result);
                return Ok();
            }
            return BadRequest();
        }

    }
}