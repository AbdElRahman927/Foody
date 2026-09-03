namespace Foody_backend.DTOs.Restaurant_DTOs
{
    public class RestaurantPendingResponseDto
    {// الداتا الحالية
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CuisineTags { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? OpeningHours { get; set; }
        public string? MenuUrl { get; set; }
        public int PriceLevel { get; set; }
        public string? ThumbnailImageUrl { get; set; }

        // الداتا الجديدة (Pending)
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

        // Status
        public string Status { get; set; } = string.Empty;
        public string? AdminComment { get; set; }
    }
}
