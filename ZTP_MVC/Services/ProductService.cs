using ZTP_MVC.Models;

namespace ZTP_MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/api/v1/");
            _httpClient = httpClient;
        }
        public async Task AddProduct(ProductDto product)
        {
            await _httpClient.PostAsJsonAsync("products", product);
        }

        public async Task AddProductQuantity(Guid productId, int quantity)
        {
            await _httpClient.PutAsync($"products/{productId}/quantityadd/{quantity}", null);
        }

        public async Task DeleteProduct(Guid productId)
        {
            await _httpClient.DeleteAsync($"products/{productId}");
        }

        public async Task<ProductResponseDto> GetProductById(Guid productId)
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<ProductResponseDto>($"products/{productId}");
                if (product == null)
                {
                    throw new FileNotFoundException($"Product with id: {productId} does not exist");
                }
                return product;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductResponseDto>> GetProducts()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<ProductResponseDto>>("products");
                if (products == null)
                {
                    products = new List<ProductResponseDto>();
                }
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SubtractProductQuantity(Guid productId, int quantity)
        {
            await _httpClient.PutAsync($"products/{productId}/quantitysubtract/{quantity}", null);
        }

        public async Task UpdateProduct(Guid productId, ProductDto product)
        {
            await _httpClient.PatchAsJsonAsync($"products/{productId}", product);
        }
    }
}
