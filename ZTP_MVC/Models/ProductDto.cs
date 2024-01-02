using System.ComponentModel.DataAnnotations;

namespace ZTP_MVC.Models
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Description is required.")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Product Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Product Quantity must be non-negative.")]
        public int ProductQuantity { get; set; }
    }
}
