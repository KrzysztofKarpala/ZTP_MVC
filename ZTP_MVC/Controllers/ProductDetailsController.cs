using Microsoft.AspNetCore.Mvc;
using ZTP_MVC.Models;
using ZTP_MVC.Services;

namespace ZTP_MVC.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductService _productService;
        public ProductDetailsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(Guid id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);
        }
        public IActionResult NavigateToProducts()
        {
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> IncrementQuantity(Guid id)
        {
            await _productService.AddProductQuantity(id, 1);
            var product = await _productService.GetProductById(id);
            return View("Index", product);
        }
        public async Task<IActionResult> SubtractQuantity(Guid id)
        {
            await _productService.SubtractProductQuantity(id, 1);
            var product = await _productService.GetProductById(id);
            return View("Index", product);
        }
        public async Task<IActionResult> Update(ProductResponseDto productResponseDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(productResponseDto.ProductId, new ProductDto() { ProductName = productResponseDto.ProductName, ProductDescription = productResponseDto.ProductDescription, ProductQuantity = productResponseDto.ProductQuantity });
                return RedirectToAction("Index", "Products");
            }

            return View("Index", productResponseDto);
        }
    }
}
