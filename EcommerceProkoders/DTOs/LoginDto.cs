using System.ComponentModel.DataAnnotations;

namespace EcommerceProkoders.DTOs
{
    public class LoginDto
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
