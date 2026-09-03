

using Foody_backend.DTOs.Auth_DTOs;
using Foody_backend.DTOs.Restaurant_DTOs;
using Foody_Backend.DTOs;

namespace Foody_backend.interfaces
{
    public interface IOwnerServices
    {
        Task RegisterOwnerAsync(RegisterDto registerDto);

        Task<OwnerAuthResponseDto?> LoginOwnerAsync(LoginDto loginDto);

        Task RegisterRestaurantAsync(int ownerId, RestaurantRegisterDto dto);
        Task UpdateRestaurantAsync(int ownerId, RestaurantPendingDto dto);
        Task ToggleVisibilityAsync(int ownerId);
        Task PublishUpdateAsync(int ownerId);
    }
}
