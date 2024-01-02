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
    public class ProductDetailsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithProduct()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);

            var productId = Guid.NewGuid();
            var product = new ProductResponseDto { ProductId = productId, ProductName = "TestProduct", ProductDescription = "Description", ProductQuantity = 10 };

            productServiceMock.Setup(service => service.GetProductById(productId)).ReturnsAsync(product);

            // Act
            var result = await productDetailsController.Index(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ProductResponseDto>(viewResult.ViewData.Model);
            Assert.Equal(productId, model.ProductId);
        }

        [Fact]
        public void NavigateToProducts_RedirectsToProductsIndex()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);

            // Act
            var result = productDetailsController.NavigateToProducts();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Products", redirectToActionResult.ControllerName);
        }

        [Fact]
        public async Task IncrementQuantity_RedirectsToIndexViewWithUpdatedProduct()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);

            var productId = Guid.NewGuid();

            // Act
            var result = await productDetailsController.IncrementQuantity(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);

            productServiceMock.Verify(service => service.AddProductQuantity(productId, 1), Times.Once);
        }

        [Fact]
        public async Task SubtractQuantity_RedirectsToIndexViewWithUpdatedProduct()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);

            var productId = Guid.NewGuid();

            // Act
            var result = await productDetailsController.SubtractQuantity(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);

            productServiceMock.Verify(service => service.SubtractProductQuantity(productId, 1), Times.Once);
        }

        [Fact]
        public async Task Update_WithValidModel_RedirectsToProductsIndex()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);

            var productResponseDto = new ProductResponseDto
            {
                ProductId = Guid.NewGuid(),
                ProductName = "UpdatedProduct",
                ProductDescription = "UpdatedDescription",
                ProductQuantity = 20
            };

            // Act
            var result = await productDetailsController.Update(productResponseDto);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Products", redirectToActionResult.ControllerName);

            productServiceMock.Verify(service => service.UpdateProduct(
                productResponseDto.ProductId,
                It.IsAny<ProductDto>()),
                Times.Once);
        }

        [Fact]
        public async Task Update_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var productDetailsController = new ProductDetailsController(productServiceMock.Object);
            productDetailsController.ModelState.AddModelError("ProductName", "Required");

            var productResponseDto = new ProductResponseDto
            {
                ProductId = Guid.NewGuid(),
                ProductName = "InvalidProduct",
                ProductDescription = "InvalidDescription",
                ProductQuantity = 10
            };

            // Act
            var result = await productDetailsController.Update(productResponseDto);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Equal(productResponseDto, viewResult.ViewData.Model);
        }
    }
}
