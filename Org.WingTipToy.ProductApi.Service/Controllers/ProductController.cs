using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Org.WingTipToy.ProductApi.Service.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("HealthCheck")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> HealthCheck()
        {
            var result = await Task.Run(() => "All Good");
            return Ok(result);
        }
    }
}
