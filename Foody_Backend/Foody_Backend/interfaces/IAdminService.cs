using Foody_backend.DTOs;
using Foody_backend.DTOs.Restaurant_DTOs;
using Foody_Backend.DTOs;

namespace Foody_backend.Interfaces
{
    public interface IAdminService
    {

        Task<AuthResponseDto?> LoginAdminAsync(LoginDto loginDto);
        //new
        Task<List<RestaurantResponseDto>> GetPendingNewRestaurantsAsync();
        Task ApproveRestaurantAsync(int restaurantId, string? adminComment);
        Task RejectRestaurantAsync(int restaurantId, string rejectionReason);
        //updates
        Task<List<RestaurantPendingResponseDto>> GetPendingUpdatesAsync();
        Task ApproveRestaurantUpdateAsync(int restaurantId, string? adminComment);
        Task RejectRestaurantUpdateAsync(int restaurantId, string rejectionReason);


    }
}
