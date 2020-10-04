using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Security.Controllers
{
    [Route("ping")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}