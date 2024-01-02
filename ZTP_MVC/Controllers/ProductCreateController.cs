using Microsoft.AspNetCore.Mvc;
using ZTP_MVC.Models;
using ZTP_MVC.Services;

namespace ZTP_MVC.Controllers
{
    public class ProductCreateController : Controller
    {
        private readonly IProductService _productService;
        public ProductCreateController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create( ProductDto productDto)
        {
            if(ModelState.IsValid)
            {
                await _productService.AddProduct(productDto);
                return RedirectToAction("Index", "Products");
            }
            return View("Index", productDto);
        }
        public IActionResult NavigateToProducts()
        {
            return RedirectToAction("Index", "Products");
        }
    }
}
