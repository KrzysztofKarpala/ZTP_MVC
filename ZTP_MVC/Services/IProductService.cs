using ZTP_MVC.Models;

namespace ZTP_MVC.Services
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetProducts();
        Task<ProductResponseDto> GetProductById(Guid productId);
        Task AddProduct(ProductDto product);
        Task UpdateProduct(Guid productId, ProductDto product);
        Task DeleteProduct(Guid productId);
        Task AddProductQuantity(Guid productId, int quantity);
        Task SubtractProductQuantity(Guid productId, int quantity);
    }
}
