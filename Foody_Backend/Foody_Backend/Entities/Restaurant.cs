namespace Foody_Backend.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CuisineTags { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double AverageRating { get; set; } = 0.0;
        public int PriceLevel { get; set; } = 1;
        public string? ThumbnailImageUrl { get; set; }
        public string Status { get; set; } = "Pending";
        public bool IsVisible { get; set; } = false;

        public string? RejectionReason { get; set; }
        public string? AdminComment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? OpeningHours { get; set; }
        public string? MenuUrl { get; set; }

        // Navigation Property
        public User Owner { get; set; } = null!;
        public RestaurantPendingUpdate? PendingUpdate { get; set; }
    }
}