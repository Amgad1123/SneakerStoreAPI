using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }    

    }
}
