
using Foody_backend.DTOs;
using Foody_backend.interfaces;
using Foody_Backend.DTOs;
using Foody_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDTO)
        {

           
                var result = await _authService.RegisterAsync(registerDTO);
                return Ok(result);

            


        }
        

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            
                var result = await _authService.LoginAsync(loginDto);
                return Ok(result);
            
        }

       


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {

                await _authService.ForgotPasswordAsync(email);
                return Ok(new { message = "If this email exists, a reset link has been sent." });

            
        }

        [HttpGet("get-profile")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetProfile()
        {

                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                var result = await _authService.GetProfileAsync(userId);

                return Ok(result);



        }

        [HttpPut("update-profile")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Updateprofile([FromBody] UserProfileDto profileDto)
        {
           
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                var result = await _authService.UpdateProfileAsync(userId, profileDto);



                return Ok(result);

          
        }

    }
}

