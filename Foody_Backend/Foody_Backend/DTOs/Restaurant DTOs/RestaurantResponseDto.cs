namespace Foody_backend.DTOs.Restaurant_DTOs
{
    public class RestaurantResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CuisineTags { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public int PriceLevel { get; set; }
        public string? ThumbnailImageUrl { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? OpeningHours { get; set; }
        public string? MenuUrl { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public string? RejectionReason { get; set; }
        public string? AdminComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
