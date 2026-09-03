
using Foody_backend.Interfaces;
using Foody_Backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foody_backend.Controllers
{

    [ApiController]
    [Route("api/Admin")]
    public class AdminController :ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController (IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("login-admin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _adminService.LoginAdminAsync(loginDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        // New Restaurants
        [HttpGet("restaurants/pending-new")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingNewRestaurants()
        {
            try
            {
                var result = await _adminService.GetPendingNewRestaurantsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("restaurants/{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveRestaurant(
            [FromRoute] int id,
            [FromBody] string? adminComment)
        {
            try
            {
                await _adminService.ApproveRestaurantAsync(id, adminComment);
                return Ok(new { message = "Restaurant approved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("restaurants/{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRestaurant(
            [FromRoute] int id,
            [FromBody] string? adminComment)
        {
            try
            {
                await _adminService.RejectRestaurantAsync(id, adminComment);
                return Ok(new { message = "Restaurant rejected successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Updates
        [HttpGet("restaurants/pending-updates")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingUpdates()
        {
            try
            {
                var result = await _adminService.GetPendingUpdatesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("restaurants/{id}/approve-update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveRestaurantUpdate(
            [FromRoute] int id,
            [FromBody] string? adminComment)
        {
            try
            {
                await _adminService.ApproveRestaurantUpdateAsync(id, adminComment);
                return Ok(new { message = "Update approved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("restaurants/{id}/reject-update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRestaurantUpdate(
            [FromRoute] int id,
            [FromBody] string? adminComment)
        {
            try
            {
                await _adminService.RejectRestaurantUpdateAsync(id, adminComment);
                return Ok(new { message = "Update rejected successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
