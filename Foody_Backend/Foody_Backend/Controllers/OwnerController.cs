using Foody_backend.DTOs;
using Foody_backend.DTOs.Restaurant_DTOs;
using Foody_backend.interfaces;
using Foody_backend.services;
using Foody_Backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foody_backend.Controllers
{
   
        [ApiController]
        [Route("api/Owner")]
        public class OwnerController: ControllerBase
        {
            private readonly IOwnerServices _ownerServices;

            public OwnerController(IOwnerServices ownerServices) {
                _ownerServices = ownerServices;
            }
            [HttpPost("register-owner")]
            public async Task<IActionResult> OwnerRegister([FromBody] RegisterDto registerDTO)
            {

                try
                {
                     await _ownerServices.RegisterOwnerAsync(registerDTO);
                    return Ok(new { message = "Owner Account registered successfully" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }


            }
            [HttpPost("login-owner")]
            public async Task<IActionResult> LoginOwner([FromBody] LoginDto loginDto)
            {
                try
                {
                    var result = await _ownerServices.LoginOwnerAsync(loginDto);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        
        
        [HttpPost("restaurant/register")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> RegisterRestaurant([FromBody] RestaurantRegisterDto dto)
        {
            try
            {
                var ownerId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                await _ownerServices.RegisterRestaurantAsync(ownerId, dto);
                return Ok(new { message = "Restaurant registered successfully, awaiting admin approval" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
       
        
        
        [HttpPut("restaurant/update")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantPendingDto dto)
        {
            try
            {
                var ownerid = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                await _ownerServices.UpdateRestaurantAsync(ownerid, dto);
                return Ok(new { message = "Update request submitted, awaiting admin approval" });
            }
            catch ( Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        
        
        
        [HttpPut("restaurant/toggle-visibility")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> ToggleVisibility()
        {
            try
            {
                var ownerId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                await _ownerServices.ToggleVisibilityAsync(ownerId);
                return Ok(new { message = "Restaurant visibility updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("restaurant/publish")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> PublishUpdate()
        {
            try
            {
                var ownerId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                await _ownerServices.PublishUpdateAsync(ownerId);
                return Ok(new { message = "Update published successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
    
}
