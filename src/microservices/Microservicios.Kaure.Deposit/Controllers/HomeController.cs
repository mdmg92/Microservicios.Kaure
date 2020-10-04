using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Deposit.Controllers
{
    [Route("ping")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}