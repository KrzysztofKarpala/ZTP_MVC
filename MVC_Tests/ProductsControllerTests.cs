using Microsoft.AspNetCore.Mvc;
using Moq;
using ZTP_MVC.Controllers;
using ZTP_MVC.Models;
using ZTP_MVC.Services;

namespace MVC_Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithProducts()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productsController = new ProductsController(productServiceMock.Object);

            var products = new List<ProductResponseDto> { new ProductResponseDto() { ProductId = Guid.NewGuid(), ProductName = "ProductNameTest1", ProductDescription = "ProductDescriptionTest1", ProductQuantity = 1}, new ProductResponseDto() { ProductId = Guid.NewGuid(), ProductName = "ProductNameTest2", ProductDescription = "ProductDescriptionTest2", ProductQuantity = 2 } };
            productServiceMock.Setup(service => service.GetProducts()).ReturnsAsync(products);

            // Act
            var result = await productsController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductResponseDto>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Create_RedirectsToIndexAction()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productsController = new ProductsController(productServiceMock.Object);

            // Act
            var result = productsController.Create();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("ProductCreate", redirectToActionResult.ControllerName);
        }

        [Fact]
        public void Details_RedirectsToIndexActionWithIdParameter()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productsController = new ProductsController(productServiceMock.Object);

            var productId = Guid.NewGuid();

            // Act
            var result = productsController.Details(productId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("ProductDetails", redirectToActionResult.ControllerName);
            Assert.Equal(productId, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task Delete_RedirectsToProductsIndexAfterDelete()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productsController = new ProductsController(productServiceMock.Object);

            var productId = Guid.NewGuid();

            // Act
            var result = await productsController.Delete(productId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Products", redirectToActionResult.ControllerName);

            productServiceMock.Verify(service => service.DeleteProduct(productId), Times.Once);
        }
    }
}
