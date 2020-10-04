using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.History.Controllers
{
    [Route("ping")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}