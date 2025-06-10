using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; }
        public int Quantity { get; set; }
    }
}
