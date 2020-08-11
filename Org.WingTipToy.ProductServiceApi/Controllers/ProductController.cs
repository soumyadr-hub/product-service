using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Org.WingTipToy.ProductServiceApi.Controllers
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
        public IActionResult Get()
        {
            return Ok("All Good");
        }
    }
}
