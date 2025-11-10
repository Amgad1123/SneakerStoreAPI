using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public string Image { get; set; } 
    }
}
