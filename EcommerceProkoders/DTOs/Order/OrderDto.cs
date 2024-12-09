using EcommerceProkoders.Core.Entities;

namespace EcommerceProkoders.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto>? OrderItems { get; set; }
    }
}
