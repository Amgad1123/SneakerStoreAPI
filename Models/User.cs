using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; } // Store hashed passwords
        [Required]
        public string Role { get; set; } = "Customer"; // Default role

        public ICollection<Order> Orders { get; set; }
    }
}
