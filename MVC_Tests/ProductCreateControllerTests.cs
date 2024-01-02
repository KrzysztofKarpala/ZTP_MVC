using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_MVC.Controllers;
using ZTP_MVC.Models;
using ZTP_MVC.Services;

namespace MVC_Tests
{
    public class ProductCreateControllerTests
    {

        [Fact]
        public async Task Create_WithValidModel_RedirectsToProductsIndex()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productCreateController = new ProductCreateController(productServiceMock.Object);

            var productDto = new ProductDto
            {
                ProductName = "NewProduct",
                ProductDescription = "Description",
                ProductQuantity = 10
            };

            // Act
            var result = await productCreateController.Create(productDto);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Products", redirectToActionResult.ControllerName);

            productServiceMock.Verify(service => service.AddProduct(productDto), Times.Once);
        }

        [Fact]
        public async Task Create_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productCreateController = new ProductCreateController(productServiceMock.Object);
            productCreateController.ModelState.AddModelError("ProductName", "Required");

            var productDto = new ProductDto
            {
                ProductName = "InvalidProduct",
                ProductDescription = "InvalidDescription",
                ProductQuantity = -10
            };

            // Act
            var result = await productCreateController.Create(productDto);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Equal(productDto, viewResult.ViewData.Model);
        }

        [Fact]
        public void NavigateToProducts_RedirectsToProductsIndex()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productCreateController = new ProductCreateController(productServiceMock.Object);

            // Act
            var result = productCreateController.NavigateToProducts();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Products", redirectToActionResult.ControllerName);
        }
    }
}
