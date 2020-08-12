using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Org.WingTipToy.ProductApi.Service.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace Org.WingTipToy.ProductApi.Test
{
    public class ProductControllerTest
    {
        public ProductControllerTest()
        {
            var mockLogger = Mock.Of<ILogger<ProductController>>();
            Controller = new ProductController(mockLogger);
        }

        public ProductController Controller { get; set; }

        [Fact]
        public async Task Success_HealthCheck_ReturnCorrectResult()
        {
            //Arrange

            //Act
            var actualActionResult = await Controller.HealthCheck().ConfigureAwait(false);

            //Assert
            actualActionResult.Should().BeOfType<OkObjectResult>();
            var actualResult = actualActionResult as OkObjectResult;
            actualResult.Value.Should().BeEquivalentTo("All Good");
        }
    }
}
