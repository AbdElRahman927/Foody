using Foody_backend.DTOs;
using Foody_Backend.DTOs;
using Foody_Backend.Entities;
using Foody_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Foody_backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;


        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {

            try
            {
                var result = await _authService.RegisterAsync(registerDTO);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {

            try
            {
                await _authService.ForgotPasswordAsync(email);
                return Ok(new { message = "If this email exists, a reset link has been sent." });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {

            try {
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                var result = await _authService.GetProfileAsync(userId);

                if (result == null) return NotFound(new { message = "User not found" });

                return Ok(result);

            } catch (Exception ex) 
            {
                return BadRequest(new {message=ex.Message});
            }


        }

        [HttpPut("update-profile")]
        [Authorize]
        public async Task<IActionResult> Updateprofile([FromBody] UserProfileDto profileDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                var result = await _authService.UpdateProfileAsync(userId, profileDto);

                if (result == null) return NotFound(new { });

                return Ok(result);

            }catch(Exception ex) {
                return  BadRequest(new {message=ex.Message});
            }
        }

    }
}

