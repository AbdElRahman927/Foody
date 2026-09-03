
using Foody_backend.DTOs;
using Foody_backend.DTOs.Restaurant_DTOs;
using Foody_backend.Exceptions;
using Foody_backend.Interfaces;
using Foody_Backend.Data;
using Foody_Backend.DTOs;
using Foody_Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Foody_backend.services
{
    public class AdminServices : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public AdminServices(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"]!;
            var issuer = jwtSettings["Issuer"]!;
            var audience = jwtSettings["Audience"]!;
            var expiryInDays = int.Parse(jwtSettings["ExpiryInDays"]!);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Email, user.Email),
    new Claim(ClaimTypes.Name, user.FullName),
    new Claim(ClaimTypes.Role, user.Role)
};

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(expiryInDays),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<AuthResponseDto?> LoginAdminAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.email);

            if (user == null || user.Role != "Admin")
                throw new ValidationException("Invalid email or password");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!isPasswordValid)
                throw new ValidationException("Invalid email or password");

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                Role = user.Role
            };
        }

        //new restaurants

        public async Task<List<RestaurantResponseDto>> GetPendingNewRestaurantsAsync()
        {
            var restaurants = await _context.Restaurants
                .Where(r => r.Status == "Pending")
                .Select(r => new RestaurantResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    CuisineTags = r.CuisineTags,
                    Description = r.Description,
                    AverageRating = r.AverageRating,
                    PriceLevel = r.PriceLevel,
                    ThumbnailImageUrl = r.ThumbnailImageUrl,
                    Phone = r.Phone,
                    Website = r.Website,
                    Facebook = r.Facebook,
                    Instagram = r.Instagram,
                    OpeningHours = r.OpeningHours,
                    MenuUrl = r.MenuUrl,
                    Status = r.Status,
                    IsVisible = r.IsVisible,
                    RejectionReason = r.RejectionReason,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt,
                    AdminComment = r.AdminComment

                })
                .ToListAsync();

            return restaurants;
        }

        public async Task ApproveRestaurantAsync(int restaurantId, string? adminComment)
        {
            // ① نجيب المطعم
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ② نتأكد إنه Pending
            if (restaurant.Status != "Pending")
                throw new ValidationException("Restaurant is not pending approval");

            // ③ نغير Status
            restaurant.Status = "Approved";
            restaurant.UpdatedAt = DateTime.UtcNow;

            // ④ نحفظ AdminComment في Restaurant


            if (restaurant != null && adminComment != null)
                restaurant.AdminComment = adminComment;

            await _context.SaveChangesAsync();
        }

        public async Task RejectRestaurantAsync(int restaurantId, string? adminComment)
        {
            // ① نجيب المطعم
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ② نتأكد إنه Pending
            if (restaurant.Status != "Pending")
                throw new ValidationException("Restaurant is not pending approval");

            // ③ نغير Status
            restaurant.Status = "Rejected";
            restaurant.AdminComment = adminComment;
            restaurant.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        //exsited restaurants updates 

        public async Task<List<RestaurantPendingResponseDto>> GetPendingUpdatesAsync()
        {
            var pendingUpdates = await _context.RestaurantsPendingUpdates
                .Where(p => p.Status == "Pending")
                .Include(p => p.Restaurant)
                .Select(p => new RestaurantPendingResponseDto
                {
                    // الداتا الحالية من Restaurant
                    Id = p.Restaurant.Id,
                    Name = p.Restaurant.Name,
                    City = p.Restaurant.City,
                    CuisineTags = p.Restaurant.CuisineTags,
                    Description = p.Restaurant.Description,
                    Phone = p.Restaurant.Phone,
                    Website = p.Restaurant.Website,
                    Facebook = p.Restaurant.Facebook,
                    Instagram = p.Restaurant.Instagram,
                    OpeningHours = p.Restaurant.OpeningHours,
                    MenuUrl = p.Restaurant.MenuUrl,
                    PriceLevel = p.Restaurant.PriceLevel,
                    ThumbnailImageUrl = p.Restaurant.ThumbnailImageUrl,

                    // الداتا الجديدة من PendingUpdate
                    PendingName = p.PendingName,
                    PendingDescription = p.PendingDescription,
                    PendingCuisineTags = p.PendingCuisineTags,
                    PendingThumbnailImageUrl = p.PendingThumbnailImageUrl,
                    PendingPriceLevel = p.PendingPriceLevel,
                    PendingPhone = p.PendingPhone,
                    PendingWebsite = p.PendingWebsite,
                    PendingFacebook = p.PendingFacebook,
                    PendingInstagram = p.PendingInstagram,
                    PendingOpeningHours = p.PendingOpeningHours,
                    PendingMenuUrl = p.PendingMenuUrl,

                    // Status
                    Status = p.Status,
                    AdminComment = p.Restaurant.AdminComment
                })
                .ToListAsync();

            return pendingUpdates;
        }

        public async Task ApproveRestaurantUpdateAsync(int restaurantId, string? adminComment)
        {
            // ① نجيب الـ PendingUpdate
            var pendingUpdate = await _context.RestaurantsPendingUpdates
                .FirstOrDefaultAsync(p => p.RestaurantId == restaurantId);

            if (pendingUpdate == null)
                throw new NotFoundException("No pending update found");

            if (pendingUpdate.Status != "Pending")
                throw new ValidationException("No pending update to approve");

            // ② نجيب الـ Restaurant
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ③ نحدث الـ PendingUpdate Status
            pendingUpdate.Status = "Approved";
            pendingUpdate.IsUpdated = false;
            pendingUpdate.HasPendingUpdate = false;
            pendingUpdate.UpdatedAt = DateTime.UtcNow;

            // ④ نحفظ AdminComment في Restaurant
            restaurant.AdminComment = adminComment;
            restaurant.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task RejectRestaurantUpdateAsync(int restaurantId, string? adminComment)
        {
            // ① نجيب الـ PendingUpdate
            var pendingUpdate = await _context.RestaurantsPendingUpdates
                .FirstOrDefaultAsync(p => p.RestaurantId == restaurantId);

            if (pendingUpdate == null)
                throw new NotFoundException("No pending update found");

            if (pendingUpdate.Status != "Pending")
                throw new NotFoundException("No pending update to reject");

            // ② نجيب الـ Restaurant
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ③ نصفر الـ PendingUpdate
            pendingUpdate.PendingName = null;
            pendingUpdate.PendingDescription = null;
            pendingUpdate.PendingCuisineTags = null;
            pendingUpdate.PendingThumbnailImageUrl = null;
            pendingUpdate.PendingPriceLevel = null;
            pendingUpdate.PendingPhone = null;
            pendingUpdate.PendingWebsite = null;
            pendingUpdate.PendingFacebook = null;
            pendingUpdate.PendingInstagram = null;
            pendingUpdate.PendingOpeningHours = null;
            pendingUpdate.PendingMenuUrl = null;
            pendingUpdate.HasPendingUpdate = false;
            pendingUpdate.Status = "Rejected";
            pendingUpdate.UpdatedAt = DateTime.UtcNow;

            // ④ نحفظ AdminComment في Restaurant
            restaurant.AdminComment = adminComment;
            restaurant.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
