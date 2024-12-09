namespace EcommerceProkoders.DTOs.Order
{
    public class CreateUpdateOrderHeader
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<CreateUpdateOrderItem> OrderItems { get; set; } = new List<CreateUpdateOrderItem>();
    }
}
