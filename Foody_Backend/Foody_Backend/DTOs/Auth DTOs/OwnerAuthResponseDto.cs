namespace Foody_backend.DTOs.Auth_DTOs
{
    public class OwnerAuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Owner";  
        public int? RestaurantId { get; set; }
    }
}
