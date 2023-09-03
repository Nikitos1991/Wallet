using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers
{
    [ApiController]
    [Route("health-check")]
    public class HealthCheckController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetHealthChecke()
        {
            return Ok();
        }
    }
}
