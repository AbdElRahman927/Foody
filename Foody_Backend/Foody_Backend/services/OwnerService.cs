
using Foody_backend.DTOs.Auth_DTOs;
using Foody_backend.DTOs.Restaurant_DTOs;
using Foody_backend.Exceptions;
using Foody_backend.interfaces;
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
    public class OwnerService : IOwnerServices
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OwnerService> _logger;

        public OwnerService(AppDbContext context, IConfiguration configuration, ILogger<OwnerService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger= logger;
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
      
        public async Task RegisterOwnerAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registerDto.Email);

            if (existingUser != null)
                throw new ValidationException("Email already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                FullName = registerDto.Fullname,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                Gender = registerDto.Gender,
                Role = "Owner",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateToken(user);

         
        }
        public async Task<OwnerAuthResponseDto?> LoginOwnerAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.email);

            if (user == null || user.Role != "Owner")
                throw new UnauthorizedException("Invalid email or password");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!isPasswordValid)
                throw new UnauthorizedException("Invalid email or password");

            var token = GenerateToken(user);

            return new OwnerAuthResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                RestaurantId = null
            };
        }

        public async Task RegisterRestaurantAsync(int ownerId, RestaurantRegisterDto dto)
        {

            var existingRestaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.OwnerId == ownerId);

            if (existingRestaurant != null)
                throw new ValidationException("Owner already has a restaurant");

            var restaurant = new Restaurant
            {
                OwnerId = ownerId,
                Name = dto.Name,
                City = dto.City,
                CuisineTags = dto.CuisineTags,
                Description = dto.Description,
                PriceLevel = dto.PriceLevel,
                ThumbnailImageUrl = dto.ThumbnailImageUrl,
                Status = "Pending",
                IsVisible = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            var pendingUpdate = new RestaurantPendingUpdate
            {
                RestaurantId = restaurant.Id,
                HasPendingUpdate = false,
                Status = "None",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.RestaurantsPendingUpdates.Add(pendingUpdate);
            await _context.SaveChangesAsync();

          
        }
        public async Task UpdateRestaurantAsync(int ownerId, RestaurantPendingDto dto)
        {
            _logger.LogInformation("Owner {OwnerId} attempting to publish update", ownerId); 

            // ① نتأكد إن الـ Owner عنده مطعم
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.OwnerId == ownerId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ② نتأكد إن المطعم Status = "Approved"
            if (restaurant.Status != "Approved")
                throw new ValidationException("Restaurant is not approved yet");

            // ③ نتأكد إن مفيش Pending update موجود
            var pendingUpdate = await _context.RestaurantsPendingUpdates
                .FirstOrDefaultAsync(p => p.RestaurantId == restaurant.Id);

            if (pendingUpdate == null)
                throw new NotFoundException("Pending update record not found");

            if (pendingUpdate.HasPendingUpdate)
                throw new ValidationException("Already has a pending update");

            // ④ نحدث الـ PendingUpdate بالداتا الجديدة
            pendingUpdate.PendingName = dto.PendingName;
            pendingUpdate.PendingDescription = dto.PendingDescription;
            pendingUpdate.PendingCuisineTags = dto.PendingCuisineTags;
            pendingUpdate.PendingThumbnailImageUrl = dto.PendingThumbnailImageUrl;
            pendingUpdate.PendingPriceLevel = dto.PendingPriceLevel;
            pendingUpdate.PendingPhone = dto.PendingPhone;
            pendingUpdate.PendingWebsite = dto.PendingWebsite;
            pendingUpdate.PendingFacebook = dto.PendingFacebook;
            pendingUpdate.PendingInstagram = dto.PendingInstagram;
            pendingUpdate.PendingOpeningHours = dto.PendingOpeningHours;
            pendingUpdate.PendingMenuUrl = dto.PendingMenuUrl;

            // ⑤ نغير الـ Status
            pendingUpdate.HasPendingUpdate = true;
            pendingUpdate.Status = "Pending";
            pendingUpdate.IsUpdated = false;
            pendingUpdate.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            _logger.LogInformation("Update published successfully for Restaurant {RestaurantId}", restaurant.Id); // ← إضافة

        }
        public async Task ToggleVisibilityAsync(int ownerId)
        {
            // ① نجيب المطعم
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.OwnerId == ownerId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ② نتأكد إنه Approved
            if (restaurant.Status != "Approved")
                throw new ValidationException("Restaurant is not approved yet");

            // ③ نعكس قيمة IsVisible
            restaurant.IsVisible = !restaurant.IsVisible;
            restaurant.UpdatedAt = DateTime.UtcNow;

            // ④ نحفظ
            await _context.SaveChangesAsync();
        }

        public async Task PublishUpdateAsync(int ownerId)
        {
            // ① نجيب المطعم
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.OwnerId == ownerId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            // ② نجيب الـ PendingUpdate
            var pendingUpdate = await _context.RestaurantsPendingUpdates
                .FirstOrDefaultAsync(p => p.RestaurantId == restaurant.Id);

            if (pendingUpdate == null)
                throw new NotFoundException("No pending update found");

            

            // ③ نتأكد إن الـ Status = "Approved"
            if (pendingUpdate.Status != "Approved")
                throw new ValidationException("Update not approved yet");

            // ④ ننقل الداتا من PendingUpdate للـ Restaurant
            if (pendingUpdate.PendingName != null)
                restaurant.Name = pendingUpdate.PendingName;

            if (pendingUpdate.PendingDescription != null)
                restaurant.Description = pendingUpdate.PendingDescription;

            if (pendingUpdate.PendingCuisineTags != null)
                restaurant.CuisineTags = pendingUpdate.PendingCuisineTags;

            if (pendingUpdate.PendingThumbnailImageUrl != null)
                restaurant.ThumbnailImageUrl = pendingUpdate.PendingThumbnailImageUrl;

            if (pendingUpdate.PendingPriceLevel != null)
                restaurant.PriceLevel = pendingUpdate.PendingPriceLevel.Value;

            if (pendingUpdate.PendingPhone != null)
                restaurant.Phone = pendingUpdate.PendingPhone;

            if (pendingUpdate.PendingWebsite != null)
                restaurant.Website = pendingUpdate.PendingWebsite;

            if (pendingUpdate.PendingFacebook != null)
                restaurant.Facebook = pendingUpdate.PendingFacebook;

            if (pendingUpdate.PendingInstagram != null)
                restaurant.Instagram = pendingUpdate.PendingInstagram;

            if (pendingUpdate.PendingOpeningHours != null)
                restaurant.OpeningHours = pendingUpdate.PendingOpeningHours;

            if (pendingUpdate.PendingMenuUrl != null)
                restaurant.MenuUrl = pendingUpdate.PendingMenuUrl;

            restaurant.UpdatedAt = DateTime.UtcNow;

            // ⑤ نصفر الـ PendingUpdate
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
            pendingUpdate.IsUpdated = true;
            pendingUpdate.Status = "Published";
            pendingUpdate.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

    }
}
