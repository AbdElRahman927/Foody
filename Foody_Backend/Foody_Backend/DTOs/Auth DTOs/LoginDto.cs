using System.ComponentModel.DataAnnotations;

namespace Foody_Backend.DTOs
{
    public class LoginDto
    {
        [Required (ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;

    }
}
