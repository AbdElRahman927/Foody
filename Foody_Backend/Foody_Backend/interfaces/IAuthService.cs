using Foody_backend.DTOs;
using Foody_backend.DTOs.Auth_DTOs;
using Foody_Backend.DTOs;

namespace Foody_Backend.Interfaces
{
    public interface IAuthService
    {
        Task<bool?> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<bool> ForgotPasswordAsync(string email);
        Task<UserProfileDto?> GetProfileAsync(int userId);
        Task<UserProfileDto?> UpdateProfileAsync(int userId, UserProfileDto profileDto);
        
    }
}