using Microsoft.AspNetCore.Mvc;
using ZTP_MVC.Models;
using ZTP_MVC.Services;

namespace ZTP_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [HttpPost]
        public IActionResult Create()
        {
            return RedirectToAction("Index","ProductCreate");
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            return RedirectToAction("Index", "ProductDetails", new {id = id});
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index", "Products");
        }
    }
}
