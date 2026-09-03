namespace Foody_Backend.DTOs
{
    public class RestaurantListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CuisineTags { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public int PriceLevel { get; set; }
        public string? ThumbnailImageUrl { get; set; }
        public string? Description { get; set; }  
    }
}