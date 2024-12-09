using EcommerceProkoders.Core.Entities;

namespace EcommerceProkoders.DTOs.Order
{
    public class CreateUpdateOrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }
}
