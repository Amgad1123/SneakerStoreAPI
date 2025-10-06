using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; } // Store hashed passwords
        [Required]

        public ICollection<Order> Orders { get; set; }
    }
}
