using Microsoft.AspNetCore.Mvc;
using SmartSchool.Schema.Models;
using SmartSchool.Service;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(
            IAuthService authService
            )
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await authService.IsEmailRegistered(model.Email))
            {
                return BadRequest(new ErrorResponse { Message = "Email already Registered" });
            }

            if (await authService.IsMobileNoRegistered(model.MobileNo))
            {
                return BadRequest(new ErrorResponse { Message = "Mobile No already Registered" });
            }

            try
            {
                var response = await authService.RegisterAsync(model);

                if (response == null)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(model.Email) && string.IsNullOrWhiteSpace(model.MobileNo))
            {
                return BadRequest();
            }

            try
            {
                var response = await authService.LoginAsync(model);

                if (response == null)
                {
                    return Unauthorized(new ErrorResponse { Message = "Email / Mobile No or Password is incorrect" });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
