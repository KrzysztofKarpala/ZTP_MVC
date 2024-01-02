using System.ComponentModel.DataAnnotations;

namespace ZTP_MVC.Models
{
    public class ProductResponseDto
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        [Required(ErrorMessage = "Product Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Product Quantity must be non-negative.")]
        public int ProductQuantity { get; set; }
    }
}
