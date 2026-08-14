using Foody_backend.Interfaces;
using Foody_Backend.Data;
using Foody_Backend.DTOs;
using Foody_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foody_backend.services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _context;

        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<RestaurantListDto>> GetRestaurantsAsync(string? search, string? cuisine)
        {

            var query = _context.Restaurants.AsQueryable();

            if (!string.IsNullOrEmpty(search)) 
                query = query.Where(r => r.Name == search);

            if (string.IsNullOrEmpty(cuisine))
                query=query.Where(r=> r.CuisineTags == cuisine);

            return await query.Select(r => new RestaurantListDto
            {
                Id = r.Id,
                Name = r.Name,
                City = r.City,
                CuisineTags = r.CuisineTags,
                AverageRating = r.AverageRating,
                PriceLevel = r.PriceLevel,
                ThumbnailImageUrl = r.ThumbnailImageUrl
            }).ToListAsync();


        }
    }
}
