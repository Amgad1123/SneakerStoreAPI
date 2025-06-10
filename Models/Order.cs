using System.ComponentModel.DataAnnotations;

namespace SneakerStoreAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public User User { get; set; }
        public int UserId { get; set; } 
}
}
