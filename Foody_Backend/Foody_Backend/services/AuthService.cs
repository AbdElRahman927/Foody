using Foody_backend.DTOs;
using Foody_Backend.DTOs;
using Foody_Backend.Data;
using Foody_Backend.Entities;
using Foody_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Foody_backend.DTOs.Auth_DTOs;
using Foody_backend.Exceptions;

namespace Foody_backend.services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

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

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool?> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);

            if (existingUser != null)
            {
                throw new ValidationException("Email already exists");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var user = new User
            {
                FullName = registerDto.Fullname,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                Gender = registerDto.Gender,
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateToken(user);

            return true;


        }

       

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.email);
            if (user == null || user.Role !="User")
            {
                throw new UnauthorizedException("Invalid Email or password");
            }
            var ispasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!ispasswordValid)
            {
                throw new UnauthorizedException("Invalid Email or password");
            }
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


     
     public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
            if (user == null)
                return true;
            return true;
        }


        public async Task<UserProfileDto?> GetProfileAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
                

            return new UserProfileDto
            {
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                FavoriteCuisine = user.FavoriteCuisine
            };
        }


        public async Task<UserProfileDto?> UpdateProfileAsync(int userId, UserProfileDto profileDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            user.FullName = profileDto.FullName;
            user.Phone = profileDto.Phone;
            user.DateOfBirth = profileDto.DateOfBirth;
            user.Bio = profileDto.Bio;
            user.ProfileImageUrl = profileDto.ProfileImageUrl;
            user.FavoriteCuisine = profileDto.FavoriteCuisine;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new UserProfileDto
            {
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                FavoriteCuisine = user.FavoriteCuisine
            };
        }
          }
}