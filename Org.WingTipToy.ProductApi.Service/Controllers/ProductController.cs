using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.WingTipToy.ProductApi.Service.Contexts;
using System.Threading.Tasks;

namespace Org.WingTipToy.ProductApi.Service.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]/api")]
    public class ProductController : ControllerBase
    {
        //private readonly ILogger<ProductController> _logger;

        public IExecutionContext Context { get; }

        public ProductController(IExecutionContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("HealthCheck")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> HealthCheck()
        {
            var result = await Task.Run(() => "All Good");
            return Ok(result);
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await Context.DataRepository.GetCategoriesAsync().ConfigureAwait(false);

            return Ok(categories);
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await Context.DataRepository.GetProductsAsync().ConfigureAwait(false);

            return Ok(products);
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("Products/{categoryId}")]
        public async Task<IActionResult> GetProductsAsync(int categoryId)
        {
            var products = await Context.DataRepository.GetProductsAsync(categoryId).ConfigureAwait(false);

            return Ok(products);
        }
    }
}
