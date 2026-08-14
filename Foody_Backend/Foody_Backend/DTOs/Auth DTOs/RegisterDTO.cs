using System.ComponentModel.DataAnnotations;

namespace Foody_Backend.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100)]
        public String Fullname { get; set; } = String.Empty;
        [Required]
        [EmailAddress]

        public String Email { get; set; } = String.Empty;
        [Required]
        [MinLength(8)]

        public String Password {  get; set; } = String.Empty;
        [Required]
        
        public String Gender {  get; set; } = String.Empty;

    }


}