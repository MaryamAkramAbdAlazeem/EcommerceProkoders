using System.ComponentModel.DataAnnotations;

namespace EcommerceProkoders.DTOs.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //public byte[]? Image { get; set; }
    }
}
