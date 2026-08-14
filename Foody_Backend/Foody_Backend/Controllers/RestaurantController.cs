using Foody_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foody_Backend.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants(
            [FromQuery] string? search,
            [FromQuery] string? cuisine)
        {
            try
            {
                var result = await _restaurantService.GetRestaurantsAsync(search, cuisine);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}