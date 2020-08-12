using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Org.WingTipToy.ProductApi.BusinessLogic.Repositories;
using Org.WingTipToy.ProductApi.DataEntity;
using Org.WingTipToy.ProductApi.Service.Contexts;
using Org.WingTipToy.ProductApi.Service.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Org.WingTipToy.ProductApi.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task Success_HealthCheck_ReturnCorrectResult()
        {
            //Arrange
            var mockDataRepository = Mock.Of<IDataRepository>();
            var mockExecutionContext = new ExecutionContext(mockDataRepository);
            var controller = new ProductController(mockExecutionContext);

            //Act
            var actualActionResult = await controller.HealthCheck().ConfigureAwait(false);

            //Assert
            actualActionResult.Should().BeOfType<OkObjectResult>();
            var actualResult = actualActionResult as OkObjectResult;
            actualResult.Value.Should().BeEquivalentTo("All Good");
        }

        [Fact]
        public async Task Success_GetCategoriesAsync_ReturnCorrectResult()
        {
            //Arrange
            var mockDataRepository = Mock.Of<IDataRepository>();
            Mock.Get(mockDataRepository)
                .Setup(repo => repo.GetCategoriesAsync())
                .ReturnsAsync(new List<Category>
                {
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "TestCategory",
                        Description = "TestDescription"
                    }
                });
            var mockExecutionContext = new ExecutionContext(mockDataRepository);
            var controller = new ProductController(mockExecutionContext);

            //Act
            var actualActionResult = await controller.GetCategoriesAsync().ConfigureAwait(false);

            //Assert
            actualActionResult.Should().BeOfType<OkObjectResult>();
            var actualResult = actualActionResult as OkObjectResult;
            var actualValue = actualResult.Value as IList<Category>;
            actualValue.Count.Should().Be(1);
            actualValue.Should().BeEquivalentTo(new List<Category>
                {
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "TestCategory",
                        Description = "TestDescription"
                    }
                });
        }

        [Fact]
        public async Task Success_GetProductsAsync_ReturnCorrectResult()
        {
            //Arrange
            var mockDataRepository = Mock.Of<IDataRepository>();
            Mock.Get(mockDataRepository)
                .Setup(repo => repo.GetProductsAsync())
                .ReturnsAsync(new List<Product>
                {
                    new Product
                    {
                        ProductID = 1,
                        ProductName = "TestProduct1",
                        Description = "TestDescription1",
                        ImagePath = "TestImagePath1",
                        UnitPrice = 1.5,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "TestProduct2",
                        Description = "TestDescription2",
                        ImagePath = "TestImagePath2",
                        UnitPrice = 2.5,
                        CategoryID = 2
                    }
                });
            var mockExecutionContext = new ExecutionContext(mockDataRepository);
            var controller = new ProductController(mockExecutionContext);

            //Act
            var actualActionResult = await controller.GetProductsAsync().ConfigureAwait(false);

            //Assert
            actualActionResult.Should().BeOfType<OkObjectResult>();
            var actualResult = actualActionResult as OkObjectResult;
            var actualValue = actualResult.Value as IList<Product>;
            actualValue.Count.Should().Be(2);
            actualValue.Should().BeEquivalentTo(new List<Product>
                {
                    new Product
                    {
                        ProductID = 1,
                        ProductName = "TestProduct1",
                        Description = "TestDescription1",
                        ImagePath = "TestImagePath1",
                        UnitPrice = 1.5,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "TestProduct2",
                        Description = "TestDescription2",
                        ImagePath = "TestImagePath2",
                        UnitPrice = 2.5,
                        CategoryID = 2
                    }
                });
        }

        [Fact]
        public async Task Success_GetProductsByCategoryAsync_ReturnCorrectResult()
        {
            //Arrange
            var mockDataRepository = Mock.Of<IDataRepository>();
            Mock.Get(mockDataRepository)
                .Setup(repo => repo.GetProductsAsync(2))
                .ReturnsAsync(new List<Product>
                {
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "TestProduct2",
                        Description = "TestDescription2",
                        ImagePath = "TestImagePath2",
                        UnitPrice = 2.5,
                        CategoryID = 2
                    }
                });
            var mockExecutionContext = new ExecutionContext(mockDataRepository);
            var controller = new ProductController(mockExecutionContext);

            //Act
            var actualActionResult = await controller.GetProductsAsync(2).ConfigureAwait(false);

            //Assert
            actualActionResult.Should().BeOfType<OkObjectResult>();
            var actualResult = actualActionResult as OkObjectResult;
            var actualValue = actualResult.Value as IList<Product>;
            actualValue.Count.Should().Be(1);
            actualValue.Should().BeEquivalentTo(new List<Product>
                {
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "TestProduct2",
                        Description = "TestDescription2",
                        ImagePath = "TestImagePath2",
                        UnitPrice = 2.5,
                        CategoryID = 2
                    }
                });
        }
    }
}
