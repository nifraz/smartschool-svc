using Microsoft.AspNetCore.Mvc;
using SmartSchool.Service.Models;
using SmartSchool.Service.Services;

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
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await authService.IsEmailRegistered(model.Email))
            {
                return BadRequest(new ErrorResponse { Message = "Email already Registered." });
            }

            if (await authService.IsMobileNoRegistered(model.MobileNo))
            {
                return BadRequest(new ErrorResponse { Message = "Mobile No already Registered." });
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

        [HttpPut("verify")]
        public async Task<IActionResult> Verify([FromBody] VerifyRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(model.Email) && string.IsNullOrWhiteSpace(model.MobileNo))
            {
                ModelState.AddModelError(string.Empty, "Email or Mobile No is required.");
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(model.EmailOtp) && string.IsNullOrWhiteSpace(model.EmailToken))
            {
                ModelState.AddModelError(string.Empty, "OTP or Token is required.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await authService.VerifyAsync(model);

                if (response == null)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorResponse { Message = ex.Message });
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
                ModelState.AddModelError(string.Empty, "Email or Mobile No is required.");
                return BadRequest();
            }

            try
            {
                var response = await authService.LoginAsync(model);

                if (response == null)
                {
                    return Unauthorized(new ErrorResponse { Message = "Email / Mobile No or Password is incorrect." });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("user/{id}")]
        //public async Task<IActionResult> User([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var response = await authService.GetUserAsync(id);

        //        if (response == null)
        //        {
        //            return NotFound(new ErrorResponse { Message = "User not found." });
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
