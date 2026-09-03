using Foody_Backend.Entities;

public class RestaurantPendingUpdate
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string? PendingName { get; set; }
    public string? PendingDescription { get; set; }
    public string? PendingCuisineTags { get; set; }
    public string? PendingThumbnailImageUrl { get; set; }
    public int? PendingPriceLevel { get; set; }

    public string? PendingPhone { get; set; }
    public string? PendingWebsite { get; set; }
    public string? PendingFacebook { get; set; }
    public string? PendingInstagram { get; set; }
    public string? PendingOpeningHours { get; set; }
    public string? PendingMenuUrl { get; set; }
    public bool IsUpdated { get; set; } = false;
    public bool HasPendingUpdate { get; set; } = false;
    public string Status { get; set; } = "None";
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Property
    public Restaurant Restaurant { get; set; } = null!;
}