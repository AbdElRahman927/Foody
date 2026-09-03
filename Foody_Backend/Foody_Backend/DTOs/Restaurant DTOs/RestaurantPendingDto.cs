using System.ComponentModel.DataAnnotations;

namespace Foody_backend.DTOs.Restaurant_DTOs
{
    public class RestaurantPendingDto
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string? PendingName { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
        public string? PendingDescription { get; set; }
        public string? PendingCuisineTags { get; set; }
        public string? PendingThumbnailImageUrl { get; set; }


        [Range(1, 4, ErrorMessage = "Price level must be between 1 and 4")]
        public int? PendingPriceLevel { get; set; }


        public string? PendingPhone { get; set; }
        public string? PendingWebsite { get; set; }
        public string? PendingFacebook { get; set; }
        public string? PendingInstagram { get; set; }
        public string? PendingOpeningHours { get; set; }
        public string? PendingMenuUrl { get; set; }
    }
}
