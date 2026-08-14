namespace Foody_Backend.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CuisineTags { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double AverageRating { get; set; } = 0.0;
        public int PriceLevel { get; set; } = 1;
        public string? ThumbnailImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}