using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string PasswordHash { get; set; } // Store hashed passwords
        [Required]

        public ICollection<Order> Orders { get; set; }
    }
}
