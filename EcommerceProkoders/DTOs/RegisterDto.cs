using System.ComponentModel.DataAnnotations;

namespace EcommerceProkoders.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        // Optional: Role can be assigned during registration if needed
        public string Role { get; set; } = "User"; // Default role
    }
}
