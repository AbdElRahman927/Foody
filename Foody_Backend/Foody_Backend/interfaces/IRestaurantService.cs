using Foody_Backend.DTOs;

namespace Foody_backend.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantListDto>> GetRestaurantsAsync(string ? search ,string ? cuisine);
    }
}
