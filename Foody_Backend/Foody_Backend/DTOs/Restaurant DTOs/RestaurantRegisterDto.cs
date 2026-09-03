using System.ComponentModel.DataAnnotations;

namespace Foody_Backend.DTOs
{
    public class RestaurantRegisterDto
    {
        [Required(ErrorMessage = "Restaurant name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cuisine tags are required")]
        public string CuisineTags { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 4, ErrorMessage = "Price level must be between 1 and 4")]
        public int PriceLevel { get; set; } = 1;

        public string? ThumbnailImageUrl { get; set; }
    }
}